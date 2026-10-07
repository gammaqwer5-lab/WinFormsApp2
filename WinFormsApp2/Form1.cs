using Npgsql;
using System.Data.Common;
using System.Diagnostics;
using System.Text;
using System.Xml.Linq;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        DbProviderFactory factory;
        DbConnection connection;
        string connStr = "";
        public Form1()
        {
            InitializeComponent();
        }
        async private void button6_Click(object sender, EventArgs e)
        {
            factory = NpgsqlFactory.Instance;
            connection = factory.CreateConnection()!;

            connection.ConnectionString = connStr;
            await connection.OpenAsync();
        }

        static async Task ShowCrewAsync(DbProviderFactory factory, DbConnection connection, RichTextBox richTextBox)
        {
            DbCommand command = factory.CreateCommand()!;
            command.Connection = connection;
            command.CommandText = "SELECT id, name, role, health, status " +
                "FROM crew ORDER BY id";

            using DbDataReader reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                string line = $"{reader.GetInt32(0),-3} " +
                              $"{reader.GetString(1),-35} " +
                              $"{reader.GetString(2),-20} " +
                              $"{reader.GetInt32(3),-10} " +
                              $"{reader.GetString(4),-20}\n";

                richTextBox.AppendText(line);
            }
        }

        static async Task FindPeople(DbProviderFactory factory, DbConnection connection, RichTextBox richTextBox, System.Windows.Forms.TextBox textBox)
        {
            DbCommand command = factory.CreateCommand()!;
            command.Connection = connection;
            command.CommandText = "SELECT id, name, role, health, status " +
                "FROM crew WHERE name ILIKE @name;";

            var parameter = command.CreateParameter();
            parameter.ParameterName = "@name";
            parameter.Value = $"%{textBox.Text}%";
            command.Parameters.Add(parameter);

            using DbDataReader reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                string line = $"{reader.GetInt32(0),-3} " +
                              $"{reader.GetString(1),-35} " +
                              $"{reader.GetString(2),-20} " +
                              $"{reader.GetInt32(3),-10} " +
                              $"{reader.GetString(4),-20}\n";

                richTextBox.AppendText(line);
            }
        }

        static async Task CheckCrewAsync(DbProviderFactory factory, string connectionString, RichTextBox richTextBox)
        {
            using DbConnection conn = factory.CreateConnection()!;
            conn.ConnectionString = connectionString;
            await conn.OpenAsync();

            DbCommand command = factory.CreateCommand()!;
            command.Connection = conn;
            command.CommandText = "SELECT id, name, health FROM crew";

            List<string> deadCrew = new List<string>();
            using DbDataReader reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                int health = reader.GetInt32(2);

                if (health <= 0)
                {
                    deadCrew.Add($"{id} {name}");
                }
            }

            richTextBox.AppendText("Экипаж: ");
            if (deadCrew.Count == 0)
            {
                richTextBox.AppendText("OK\n");
            }
            else
            {
                foreach (var member in deadCrew)
                {
                    richTextBox.AppendText($"Умер: {member}\n");
                }
            }
        }
        static async Task CheckSystemsAsync(DbProviderFactory factory, string connectionString, RichTextBox richTextBox)
        {
            using DbConnection conn = factory.CreateConnection()!;
            conn.ConnectionString = connectionString;
            await conn.OpenAsync();

            DbCommand command = factory.CreateCommand()!;
            command.Connection = conn;
            command.CommandText = "SELECT name, status " +
                "FROM station_systems ORDER BY id";

            using DbDataReader reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                string line = $"{reader.GetString(0),-35} " +
                              $"{reader.GetString(1)}\n";

                richTextBox.AppendText(line);
            }
        }
        static async Task CheckConnectAsync(DbProviderFactory factory, string connectionString, RichTextBox richTextBox)
        {
            using DbConnection conn = factory.CreateConnection()!;
            conn.ConnectionString = connectionString;
            await conn.OpenAsync();

            DbCommand command = factory.CreateCommand()!;
            command.Connection = conn;
            command.CommandText = "SELECT now()";

            Stopwatch stopwatch = Stopwatch.StartNew();
            command.ExecuteNonQuery();
            stopwatch.Stop();

            richTextBox.AppendText($"Связь: {stopwatch.ElapsedMilliseconds} мс\n");
        }

        async private void button1_Click(object sender, EventArgs e)
        {
            await ShowCrewAsync(factory, connection, richTextBox1!);
        }
        async private void button2_Click(object sender, EventArgs e)
        {
            await FindPeople(factory, connection, richTextBox1!, textBox1!);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu(factory, connection);
            menu.Show();
        }

        async private void button4_Click(object sender, EventArgs e)
        {
            await CheckCrewAsync(factory, connStr, richTextBox1!);
            await CheckSystemsAsync(factory, connStr, richTextBox1!);
            await CheckConnectAsync(factory, connStr, richTextBox1!);
        }
        async private void button5_Click(object sender, EventArgs e)
        {
            richTextBox1.AppendText($"ВНИМАНИЕ!\n");
            richTextBox1.AppendText($"Проверка систем...\n");

            Task crewTask = CheckCrewAsync(factory, connStr, richTextBox1!);
            Task systemsTask = CheckSystemsAsync(factory, connStr, richTextBox1!);
            Task connectionTask = CheckConnectAsync(factory, connStr, richTextBox1!);
            
            await Task.WhenAll(
                crewTask,
                systemsTask,
                connectionTask
            );
        }

        async private void button7_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void FillTbale_Click(object sender, EventArgs e)
        {
            FillTable(factory, connection);
        }
        private void button8_Click(object sender, EventArgs e)
        {
            SystemTable(factory, connection);
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        static void SystemTable(DbProviderFactory factory, DbConnection connection)
        {
            string createTableSql =
                "CREATE TABLE IF NOT EXISTS station_systems (" +
                "id integer GENERATED ALWAYS AS IDENTITY PRIMARY KEY, " +
                "name varchar(100) NOT NULL, " +
                "status varchar(30) NOT NULL);";

            using DbCommand commandCreate = factory.CreateCommand()!;

            commandCreate.Connection = connection;
            commandCreate.CommandText = createTableSql;
            commandCreate.ExecuteNonQuery();

            string commandStr =
                "INSERT INTO station_systems (name, status)" +
                "VALUES('Двигатели', 'OK')," +
                "('Жизнеобеспечение', 'OK')," +
                "('Навигация', 'WARNING')," +
                "('Связь', 'OK')";

            DbCommand command = factory.CreateCommand()!;
            command.Connection = connection;
            command.CommandText = commandStr;
            command.ExecuteNonQuery();
        }
        static void FillTable(DbProviderFactory factory, DbConnection connection)
        {
            string commandStr =
                "INSERT INTO crew (name, role, health, status)" +
                "VALUES('Алексей Волков', 'Командир', 100, 'На станции')," +
                "('Мария Орлова', 'Инженер', 85, 'На станции')," +
                "('Дмитрий Соколов', 'Пилот', 92, 'На станции')," +
                "('Анна Крылова', 'Медик', 100, 'На станции')," +
                "('Илья Морозов', 'Инженер', 73, 'На станции')";

            DbCommand command = factory.CreateCommand()!;
            command.Connection = connection;
            command.CommandText = commandStr;
            command.ExecuteNonQuery();
        }
    }
}
