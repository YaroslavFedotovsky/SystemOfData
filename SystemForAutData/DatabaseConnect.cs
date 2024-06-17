using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace SystemForAutData
{
    public class DatabaseConnect
    {
        private NpgsqlConnection connection;

        //Метод подключения к базе данных
        public DatabaseConnect()
        {
            string connectionString = "Host=127.0.0.1;Port=5432;Database=DataSystem;Username=postgres;Password=12345678";
            connection = new NpgsqlConnection(connectionString);
        }

        //Метод открытия соединения с БД
        public void OpenConnection()
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show("Ошибка подключения к базе данных: " + ex.Message);
            }
        }

        //Метод закрытия соединения с БД
        public void CloseConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public DataTable SelectData(string query)
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection))
                {
                    adapter.Fill(dataTable);
                }
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show("Ошибка запроса " + ex.Message);
            }

            return dataTable;
        }

        private void ExecuteNonQuery(string query)
        {
            try
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, connection))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка выполнения SQL-запроса: " + ex.Message);
            }
        }

        //Метод для авторизации пользователя, используется для получения данных об организации пользователя
        public bool AuthenticateUser(string login, string password)
        {
            bool isAuthenticated = false;

            try
            {
                OpenConnection();

                using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT COUNT(*) FROM users WHERE login = @login AND password = @password", connection))
                {
                    cmd.Parameters.AddWithValue("login", login);
                    cmd.Parameters.AddWithValue("password", password);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    isAuthenticated = count > 0;
                }
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show("Ошибка выполнения SQL-запроса: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return isAuthenticated;
        }

        //Получение данных о культуре
        public DataTable GetCultures()
        {
            string query = "SELECT id, culture_name FROM Cultures";
            return SelectData(query);
        }

        //Получение данных об организации
        public DataTable GetOrganization()
        {
            string query = "SELECT id, name FROM Organization";
            return SelectData(query);
        }

        //Получение данных о ролях
        public DataTable GetRole()
        {
            string query = "SELECT id, role FROM Roles";
            return SelectData(query);
        }

        //Получение данных об организации пользователя
        public string GetOrganizationNameForUser(string login, string password)
        {
            string organizationName = "";

            try
            {
                OpenConnection();

                string query = "SELECT organization.name " +
                               "FROM users " +
                               "JOIN organization ON users.organization_id = organization.id " +
                               "WHERE users.login = @login AND users.password = @password";

                using (NpgsqlCommand cmd = new NpgsqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@login", login);
                    cmd.Parameters.AddWithValue("@password", password);

                    DataTable resultTable = SelectDataOrganization(cmd);

                    if (resultTable.Rows.Count > 0)
                    {
                        organizationName = resultTable.Rows[0]["name"].ToString();
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show("Ошибка выполнения SQL-запроса " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }

            return organizationName;
        }

        //Получение данных об email пользователя
        public string GetEmailForUser(string login, string password)
        {
            string email = "";

            try
            {
                OpenConnection();

                string query = "SELECT email " +
                               "FROM users " +
                               "WHERE users.login = @login AND users.password = @password";

                using (NpgsqlCommand cmd = new NpgsqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@login", login);
                    cmd.Parameters.AddWithValue("@password", password);

                    DataTable resultTable = SelectDataOrganization(cmd);

                    if (resultTable.Rows.Count > 0)
                    {
                        email = resultTable.Rows[0]["email"].ToString();
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show("Ошибка выполнения SQL-запроса " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }

            return email;
        }

        //Вспомогательный класс для метода GetOrganizationNameForUser
        public DataTable SelectDataOrganization(NpgsqlCommand cmd)
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd))
                {
                    adapter.Fill(dataTable);
                }
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show("Ошибка выполнения SQL-запроса: " + ex.Message);
            }

            return dataTable;
        }

        //Проверка роли пользователя
        public int GetUserRoleId(string login, string password)
        {
            int userRoleId = -1; // Значение по умолчанию или код ошибки, если роль не найдена.

            try
            {
                OpenConnection();

                string query = "SELECT roles.id " +
                               "FROM users " +
                               "JOIN roles ON users.role_id = roles.id " +
                               "WHERE users.login = @login AND users.password = @password";

                using (NpgsqlCommand cmd = new NpgsqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@login", login);
                    cmd.Parameters.AddWithValue("@password", password);

                    DataTable resultTable = SelectDataOrganization(cmd);

                    if (resultTable.Rows.Count > 0)
                    {
                        // Преобразуйте значение в int.
                        userRoleId = Convert.ToInt32(resultTable.Rows[0]["id"]);
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show("Ошибка выполнения SQL-запроса " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }

            return userRoleId;
        }

        //Получение данных о пользователе
        public void GetUserData(string email, out string name, out string phone)
        {
            name = "";
            phone = "";
            try
            {
                string query = "SELECT name, phone FROM users " +
                               "WHERE users.email = @email";

                using (NpgsqlCommand cmd = new NpgsqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@email", email);

                    DataTable resultTable = SelectDataOrganization(cmd);

                    if (resultTable.Rows.Count > 0)
                    {
                        // Преобразуйте значение в int.
                        name = Convert.ToString(resultTable.Rows[0]["name"]);
                        phone = Convert.ToString(resultTable.Rows[0]["phone"]);
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Ошибка выполнения SQL-запроса " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        //Метод для DataGrid по объему выполненных работ (в кабинете пользователя)
        public void DisplayFilledDataInForms(int orgId, int stageId, System.Windows.Controls.DataGrid dataGrid)
        {
            try
            {
                OpenConnection();

                // Получаем ID организации по её имени
                string query = "SELECT cultures.culture_name as Культура, values as Объем, to_char(forms_to_fill_out.date_filling, 'yyyy-mm-dd') as Дата FROM forms_to_fill_out " +
                                    "JOIN cultures ON forms_to_fill_out.culture_id = cultures.id " +
                                    "WHERE forms_to_fill_out.culture_id = @orgId AND forms_to_fill_out.stage_id = @stageId";
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@orgId", orgId);
                    cmd.Parameters.AddWithValue("@stageId", stageId);

                    DataTable dT = new DataTable();
                    dT.Load(cmd.ExecuteReader());
                    dataGrid.ItemsSource = dT.DefaultView;
                }

            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show("Ошибка выполнения SQL-запроса " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public void DisplayRequestsForForms(string email, System.Windows.Controls.DataGrid dataGrid)
        {
            try
            {
                OpenConnection();

                // Получаем ID организации по её имени
                string userIdQuery = "SELECT id FROM users WHERE email = @email";

                using (NpgsqlCommand userIdCmd = new NpgsqlCommand(userIdQuery, connection))
                {
                    userIdCmd.Parameters.AddWithValue("@email", email);
                    int userId = Convert.ToInt32(userIdCmd.ExecuteScalar());

                    // Получаем формы для заполнения для данной организации, включая сведения о выращиваемой культуре и стадии
                    string formsQuery = "SELECT requests.request_theme as Тема, to_char(requests.request_date, 'yyyy-mm-dd') as Дата, requests.comment as Комментарий, status_request.status_name as Статус " +
                                        "FROM requests " +
                                        "JOIN status_request ON requests.status_id = status_request.id " +
                                        "WHERE requests.user_id = @userId";

                    using (NpgsqlCommand formsCmd = new NpgsqlCommand(formsQuery, connection))
                    {
                        formsCmd.Parameters.AddWithValue("@userId", userId);

                        DataTable formsTable = new DataTable();
                        formsTable.Load(formsCmd.ExecuteReader());

                        // Установка источника данных для DataGrid
                        dataGrid.ItemsSource = formsTable.DefaultView;
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show("Ошибка выполнения SQL-запроса " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public int GetIdInEmail(string email)
        {
            OpenConnection();
            string query = $"SELECT id FROM users WHERE email = '{email}'";
            DataTable resultTable = SelectData(query);
            CloseConnection();
            return resultTable.Rows.Count > 0 ? (int)resultTable.Rows[0]["Id"] : -1;
        }

        public void SaveRequestInDB(int userId, string requestTheme, string request)
        {
            try
            {
                OpenConnection();
                string query = $"INSERT INTO requests (user_id, request, request_theme, request_date) VALUES ({userId}, '{request}', '{requestTheme}', current_timestamp)";
                ExecuteNonQuery(query);

                MessageBox.Show("Данные успешно сохранены", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении данных: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                CloseConnection();
            }
        }

        public void DisplayFilledData(string selectedOrganization, DateTime? firstDate, DateTime? endDate, System.Windows.Controls.DataGrid dataGrid)
        {
            try
            {
                OpenConnection();

                // Получаем ID организации по её имени
                string orgIdQuery = "SELECT id FROM organization WHERE name = @organizationName";

                using (NpgsqlCommand orgIdCmd = new NpgsqlCommand(orgIdQuery, connection))
                {
                    orgIdCmd.Parameters.AddWithValue("@organizationName", selectedOrganization);
                    int organizationId = Convert.ToInt32(orgIdCmd.ExecuteScalar());

                    // Получаем формы для заполнения для данной организации, включая сведения о выращиваемой культуре и стадии
                    string formsQuery = "SELECT stage.name as Стадия, cultures.culture_name as Культура, forms_to_fill_out.values as Объем, to_char(forms_to_fill_out.date_filling, 'yyyy-mm-dd') as Дата " +
                                        "FROM forms_to_fill_out " +
                                        "JOIN cultures ON forms_to_fill_out.culture_id = cultures.id " +
                                        "JOIN stage ON forms_to_fill_out.stage_id = stage.id " +
                                        "WHERE forms_to_fill_out.org_id = @organizationId AND forms_to_fill_out.date_filling BETWEEN @firstDate AND @endDate";

                    using (NpgsqlCommand formsCmd = new NpgsqlCommand(formsQuery, connection))
                    {
                        formsCmd.Parameters.AddWithValue("@organizationId", organizationId);
                        formsCmd.Parameters.AddWithValue("@firstDate", firstDate);
                        formsCmd.Parameters.AddWithValue("@endDate", endDate);

                        DataTable formsTable = new DataTable();
                        formsTable.Load(formsCmd.ExecuteReader());

                        // Установка источника данных для DataGrid
                        dataGrid.ItemsSource = formsTable.DefaultView;
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show("Ошибка выполнения SQL-запроса " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        //Метод для получения количества заявок за неделю
        public int GetCountFillForWeeks(DateTime startDate, DateTime endDate)
        {
            OpenConnection();
            string query = $"SELECT COUNT(*) as count FROM forms_to_fill_out WHERE forms_to_fill_out.date_filling BETWEEN '{startDate}' AND '{endDate}'";

            DataTable result = SelectData(query);
            if (result.Rows.Count > 0)
            {
                return Convert.ToInt32(result.Rows[0]["count"].ToString());
            }
            else
            {
                return -1;
            }
        }

        //Метод для получения количества организаций, участвующих в рабочем процессе за неделю
        public int GetCountOrgForWeeks(DateTime startDate, DateTime endDate)
        {
            string query = $"SELECT COUNT(*) as count FROM (SELECT DISTINCT forms_to_fill_out.org_id FROM forms_to_fill_out WHERE forms_to_fill_out.date_filling BETWEEN '{startDate}' AND '{endDate}')";
            DataTable result = SelectData(query);
            if (result.Rows.Count > 0)
            {
                return Convert.ToInt32(result.Rows[0]["count"].ToString());
            }
            else
            {
                return -1;
            }
            // Возвращает id наименования культуры. В противном случае ставит -1
        }

        //Метод для DataGrid по объему выполненных работ (в кабинете начальника)
        public void DisplayFormsForOrganization(string selectedOrganization, System.Windows.Controls.DataGrid dataGrid)
        {
            try
            {
                OpenConnection();

                // Получаем ID организации по её имени
                string orgIdQuery = "SELECT id FROM organization WHERE name = @organizationName";

                using (NpgsqlCommand orgIdCmd = new NpgsqlCommand(orgIdQuery, connection))
                {
                    orgIdCmd.Parameters.AddWithValue("@organizationName", selectedOrganization);
                    int organizationId = Convert.ToInt32(orgIdCmd.ExecuteScalar());

                    // Получаем формы для заполнения для данной организации, включая сведения о выращиваемой культуре и стадии
                    string formsQuery = "SELECT stage.name, cultures.culture_name, forms_to_fill_out.values, to_char(forms_to_fill_out.date_filling, 'yyyy-mm-dd') " +
                                        "FROM forms_to_fill_out " +
                                        "JOIN cultures ON forms_to_fill_out.culture_id = cultures.id " +
                                        "JOIN stage ON forms_to_fill_out.stage_id = stage.id " +
                                        "WHERE forms_to_fill_out.org_id = @organizationId";

                    using (NpgsqlCommand formsCmd = new NpgsqlCommand(formsQuery, connection))
                    {
                        formsCmd.Parameters.AddWithValue("@organizationId", organizationId);

                        DataTable formsTable = new DataTable();
                        formsTable.Load(formsCmd.ExecuteReader());

                        // Установка источника данных для DataGrid
                        dataGrid.ItemsSource = formsTable.DefaultView;
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show("Ошибка выполнения SQL-запроса " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        //Метод для выпадающего списка организаций (в кабинете Начальника)
        public void FillOrganizationComboBox(System.Windows.Controls.ComboBox comboBox)
        {
            try
            {
                OpenConnection();

                string query = "SELECT DISTINCT name FROM organization WHERE NOT id=4";

                using (NpgsqlCommand cmd = new NpgsqlCommand(query, connection))
                {
                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string organizationName = reader["name"].ToString();
                        comboBox.Items.Add(organizationName);
                    }

                    reader.Close();
                }
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show("Ошибка выполнения SQL-запроса " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public int GetNowStageId(int orgId, int cultId)
        {
            OpenConnection();
            string query = $"SELECT stage_id as Stage FROM forms_to_fill_out WHERE NOT stage_id = 5 AND org_id = {orgId} AND culture_id = {cultId} ORDER BY Stage DESC, date_filling DESC LIMIT 1";
            DataTable result = SelectData(query);
            CloseConnection();
            return Convert.ToInt32(result.Rows[0]["Stage"]);
        }

        public int GetPlanOfNowStage(int orgId, int cultId)
        {
            OpenConnection();
            string query = $"SELECT values as Value FROM forms_to_fill_out WHERE stage_id = 5 AND org_id = {orgId} AND culture_id = {cultId} ORDER BY date_filling DESC LIMIT 1";
            DataTable result = SelectData(query);
            CloseConnection();
            return Convert.ToInt32(result.Rows[0]["Value"]);
        }
        
        public void GetNowStageAndValue(int orgId, int cultId, int stageId, out string stage, out string value)
        {
            OpenConnection();
            string query = "SELECT stage.name as StageName, forms_to_fill_out.values as Values FROM forms_to_fill_out " +
                                "JOIN stage ON forms_to_fill_out.stage_id = stage.id " +
                                $"WHERE org_id = {orgId} AND culture_id = {cultId} AND stage_id = {stageId} " +
                                "ORDER BY forms_to_fill_out.date_filling DESC LIMIT 1";
            DataTable result = SelectData(query);
            stage = result.Rows[0]["StageName"].ToString();
            value = result.Rows[0]["Values"].ToString();
            CloseConnection();
        }

        public void GetDataForFirstPlot(int orgId, int cultId, out double[] valueForPlot)
        {
            OpenConnection();
            string query = $"SELECT values FROM forms_to_fill_out WHERE org_id = {orgId} AND culture_id = {cultId} AND date_part('year', date_filling) = date_part('year', CURRENT_DATE) ORDER BY stage_id DESC";
            DataTable dT = SelectData(query);
            valueForPlot = new double[5];
            valueForPlot[0] = Convert.ToDouble(dT.Rows[0]["values"]);
            for(int i = dT.Rows.Count - 1; i > 0; i--)
            {
                valueForPlot[5-i] = Convert.ToDouble(dT.Rows[i]["values"]);
            }
            CloseConnection();
        }

        public double GetNowPlanValue(int orgId, int cultId)
        {
            OpenConnection();
            string query = $"SELECT values as Value FROM forms_to_fill_out WHERE stage_id = 5 AND org_id = {orgId} AND culture_id = {cultId} ORDER BY date_filling DESC LIMIT 1";
            DataTable result = SelectData(query);
            CloseConnection();
            return Convert.ToDouble(result.Rows[0]["Value"]);
        }

        public void GetFiveYearsPlanValue(int orgId, int cultId, out double[] valuesFY, out string[] years)
        {
            OpenConnection();
            string query = $"SELECT values as Values, extract(year from date_filling) as Years FROM forms_to_fill_out WHERE org_id = {orgId} AND culture_id = {cultId} AND stage_id = 5 ORDER BY Years";
            DataTable result = SelectData(query);
            valuesFY = new double[5];
            years = new string[5];
            DateTime d = DateTime.Now;
            int dYear = d.Year;
            for(int i = 5; i > 0; i--)
            {
                int dY = dYear - i + 1;
                years[5-i] = dY.ToString();
            }
            for(int j = 0; j < result.Rows.Count; j++)
            {
                int index = Array.IndexOf(years, result.Rows[j]["Years"].ToString());
                if(index > -1)
                {
                    valuesFY[index] = Convert.ToDouble(result.Rows[j]["Values"].ToString());
                }
                
            }
        }

        //Метод возвращает ID названия культуры
        public int GetCultureIdByName(string cultureName)
        {
            string query = $"SELECT id FROM cultures WHERE culture_name = '{cultureName}'";
            DataTable result = SelectData(query);
            return result.Rows.Count > 0 ? (int)result.Rows[0]["Id"] : -1; // Возвращает id наименования культуры. В противном случае ставит -1
        }

        //Метод возвращает ID названия организации
        public int GetOrgIdByName(string orgName)
        {
            string query = $"SELECT id FROM Organization WHERE name = '{orgName}'";
            DataTable result = SelectData(query);
            return result.Rows.Count > 0 ? (int)result.Rows[0]["Id"] : -1; // Возвращает id наименования культуры. В противном случае ставит -1
        }

        //Метод возвращает ID названия роли
        public int GetRoleIdByName(string roleName)
        {
            string query = $"SELECT id FROM Roles WHERE role = '{roleName}'";
            DataTable result = SelectData(query);
            return result.Rows.Count > 0 ? (int)result.Rows[0]["Id"] : -1; // Возвращает id наименования культуры. В противном случае ставит -1
        }

        //Метод сохранения данных с формы в БД
        public void SaveForms(int orgId, int stageId, int cultureId, int volumeWork)
        {
            try
            {
                OpenConnection();

                // Проверка на отсутствие формы с такой же стадией обработки, такой же культурой и у такой же организации
                string checkExistenceQuery = $"SELECT COUNT(*) FROM forms_to_fill_out WHERE stage_id = '{stageId}' AND culture_id = {cultureId} AND org_id = {orgId}";
                int count = Convert.ToInt32(SelectData(checkExistenceQuery).Rows[0][0]);

                if (count > 0)
                {
                    MessageBox.Show("Форма с такими данными уже существует.");
                    return;
                }

                // Сохранение формы данных в БД
                string addModuleQuery = $"INSERT INTO Forms_to_fill_out (org_id, culture_id, stage_id, values, date_filling) VALUES ({orgId}, {cultureId}, {stageId}, {volumeWork}, current_timestamp)";
                ExecuteNonQuery(addModuleQuery);

                MessageBox.Show("Данные успешно сохранены.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении данных: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        //Получение данных о количестве новых заявок
        public string GetCountRequests()
        {
            string query = "SELECT COUNT(*) as count FROM requests WHERE status_id = 1";
            DataTable result = SelectData(query);
            if (result.Rows.Count > 0)
            {
                return result.Rows[0]["count"].ToString();
            }
            else
            {
                return "0";
            }
        }

        //Получение данных о количестве организаций в системе
        public string GetCountOrganization()
        {
            string query = "SELECT COUNT(*) as count FROM organization";
            DataTable result = SelectData(query);
            if (result.Rows.Count > 0)
            {
                return result.Rows[0]["count"].ToString();
            }
            else
            {
                return "0";
            }
        }

        //Получение данных о количестве пользователей в системе
        public string GetCountUsers()
        {
            string query = "SELECT COUNT(*) as count FROM users";
            DataTable result = SelectData(query);
            if (result.Rows.Count > 0)
            {
                return result.Rows[0]["count"].ToString();
            }
            else
            {
                return "0";
            }
        }

        //Получение данных о количестве организаций в системе
        public string GetCountCultures()
        {
            string query = "SELECT COUNT(*) as count FROM cultures";
            DataTable result = SelectData(query);
            if (result.Rows.Count > 0)
            {
                return result.Rows[0]["count"].ToString();
            }
            else
            {
                return "0";
            }
        }

        //Получение списка всех новых заявок
        public DataGrid FillAllNewRequests(DataGrid result)
        {
            OpenConnection();
            string query = "SELECT requests.id as Id, to_char(requests.request_date, 'yyyy-mm-dd') as Дата, users.name as Контрагент, requests.request_theme as Тема, status_request.status_name as Статус " +
                           "FROM requests " +
                           "JOIN users ON requests.user_id = users.id " +
                           "JOIN status_request ON requests.status_id = status_request.id " +
                           "WHERE status_id = 1";
            DataTable dT = SelectData(query);
            result.ItemsSource = dT.DefaultView;
            CloseConnection();
            return result;

        }

        //Получение списка всех заявок
        public DataGrid FillAllRequests(DataGrid result)
        {
            OpenConnection();
            string query = "SELECT requests.id as Id, to_char(requests.request_date, 'yyyy-mm-dd') as Дата, users.name as Контрагент, requests.request_theme as Тема, status_request.status_name as Статус " +
                           "FROM requests " +
                           "JOIN users ON requests.user_id = users.id " +
                           "JOIN status_request ON requests.status_id = status_request.id";
            DataTable dT = SelectData(query);
            result.ItemsSource = dT.DefaultView;
            CloseConnection();
            return result;

        }

        //Получение данных о заявке
        public void SelectDataOfRequestForId(int id, out string userName, out string date, out string theme, out string text)
        {
            OpenConnection();
            userName = "";
            date = "";
            theme = "";
            text = "";
            try
            {
                string query = "SELECT users.name as UserName, to_char(requests.request_date, 'yyyy-mm-dd') as Date, requests.request_theme as Theme, requests.request as Text " +
                           "FROM requests " +
                           "JOIN users ON requests.user_id = users.id " +
                           $"WHERE requests.id = {id}";
                DataTable result = SelectData(query);
                userName = result.Rows[0]["userName"].ToString();
                date = result.Rows[0]["Date"].ToString();
                theme = result.Rows[0]["Theme"].ToString();
                text = result.Rows[0]["Text"].ToString();
            }
            catch (Exception ex) { MessageBox.Show("Ошибка выполнения SQL-запроса " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); }
            finally
            {
                CloseConnection();
            }
        }

        //Сохранение комментария и статуса выполнения заявки
        public void CompletingRequest(string comment, int id)
        {
            try
            {
                OpenConnection();
                string query = $"UPDATE requests SET comment = '{comment}', status_id = 2 WHERE id = {id}";
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { MessageBox.Show("Ошибка выполнения SQL-запроса " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); }
            finally
            {
                CloseConnection();
            }
        }

        //Заполнение данных о пользователях
        public void FillUsers(string selectedOrganization, System.Windows.Controls.DataGrid dataGrid)
        {
            try
            {
                OpenConnection();

                // Получаем ID организации по её имени
                string orgIdQuery = "SELECT id FROM organization WHERE name = @organizationName";

                using (NpgsqlCommand orgIdCmd = new NpgsqlCommand(orgIdQuery, connection))
                {
                    orgIdCmd.Parameters.AddWithValue("@organizationName", selectedOrganization);
                    int organizationId = Convert.ToInt32(orgIdCmd.ExecuteScalar());

                    // Получаем формы для заполнения для данной организации, включая сведения о выращиваемой культуре и стадии
                    string formsQuery = "SELECT users.id as Id, users.name as ФИО, users.phone as Телефон, users.email as Email, organization.name as Организация, roles.role as Роль " +
                                        "FROM users " +
                                        "JOIN organization ON users.organization_id = organization.id " +
                                        "JOIN roles ON users.role_id = roles.id " +
                                        "WHERE users.organization_id = @organizationId";

                    using (NpgsqlCommand formsCmd = new NpgsqlCommand(formsQuery, connection))
                    {
                        formsCmd.Parameters.AddWithValue("@organizationId", organizationId);

                        DataTable formsTable = new DataTable();
                        formsTable.Load(formsCmd.ExecuteReader());

                        // Установка источника данных для DataGrid
                        dataGrid.ItemsSource = formsTable.DefaultView;
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show("Ошибка выполнения SQL-запроса " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        //Заполнение ComboBox с ролями
        public void FillRoleComboBox(ComboBox comboBox)
        {
            try
            {
                OpenConnection();

                string query = "SELECT DISTINCT role FROM roles";

                using (NpgsqlCommand cmd = new NpgsqlCommand(query, connection))
                {
                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string organizationName = reader["role"].ToString();
                        comboBox.Items.Add(organizationName);
                    }

                    reader.Close();
                }
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show("Ошибка выполнения SQL-запроса " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        //Сохранение новых пользователей
        public void SaveNewUser(string log, string pass, string nameUs, string phoneUs, string emailUs, int orgId, int roleId)
        {
            try
            {
                OpenConnection();


                // Проверка на отсутствие формы с такой же стадией обработки, такой же культурой и у такой же организации
                string checkExistenceQuery = $"SELECT COUNT(*) FROM users WHERE login = '{log}'";
                int count = Convert.ToInt32(SelectData(checkExistenceQuery).Rows[0][0]);

                if (count > 0)
                {
                    MessageBox.Show("Пользователь с таким логином уже существует.");
                    return;
                }

                // Сохранение формы данных в БД
                string addModuleQuery = $"INSERT INTO users (login, password, name, phone, email, organization_id, role_id) VALUES ('{log}', '{pass}', '{nameUs}', '{phoneUs}', '{emailUs}', {orgId}, {roleId})";
                ExecuteNonQuery(addModuleQuery);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении данных: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        //Получение информации о пользователе
        public void GetInfoForUsers(int id, out string familie, out string name, out string patronymic, out string email, out string phone, out string login, out string pass, out string org, out string role)
        {
            OpenConnection();
            familie = "";
            name = "";
            patronymic = "";
            email = "";
            phone = "";
            login = "";
            pass = "";
            org = "";
            role = "";
            try
            {
                string query = "SELECT users.name as Name, users.email as Email, users.phone as Phone, users.login as Login, users.password as Pass, organization.name as Org, roles.role as Role " +
                           "FROM users " +
                           "JOIN organization ON users.organization_id = organization.id " +
                           "JOIN roles ON users.role_id = roles.id " +
                           $"WHERE users.id = {id}";
                DataTable dt = SelectData(query);
                string[] userName = dt.Rows[0]["Name"].ToString().Split(' ');
                familie = userName[0];
                name = userName[1];
                if (userName.Length > 2)
                {
                    patronymic = userName[2];
                }
                email = dt.Rows[0]["Email"].ToString();
                phone = dt.Rows[0]["Phone"].ToString();
                login = dt.Rows[0]["Login"].ToString();
                pass = dt.Rows[0]["Pass"].ToString();
                org = dt.Rows[0]["Org"].ToString();
                role = dt.Rows[0]["Role"].ToString();
            }
            catch (Exception ex) { MessageBox.Show("Ошибка выполнения SQL-запроса " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); }
            finally { CloseConnection(); }
        }

        //Редактирование пользователя
        public void EditUser(int id, string login, string password, string name, string phone, string email, int orgId, int roleId)
        {
            OpenConnection();
            try
            {
                string query = $"UPDATE users SET login = '{login}', password = '{password}', name = '{name}', phone = '{phone}', email = '{email}', organization_id = {orgId}, role_id = {roleId} WHERE id = {id}";
                ExecuteNonQuery(query);
                MessageBox.Show("Пользователь успешно отредактирован", "Успешно", MessageBoxButton.OK, MessageBoxImage.None);
            }
            catch (Exception ex) { MessageBox.Show("Ошибка выполнения SQL-запроса " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); }
            finally { CloseConnection(); }
        }

        //Удаление пользователя
        public void DeleteUser(int id)
        {
            OpenConnection();
            try
            {
                string query = $"DELETE FROM users WHERE id = {id}";
                ExecuteNonQuery(query);
                MessageBox.Show("Пользователь успешно удален", "Успешно", MessageBoxButton.OK, MessageBoxImage.None);
            }
            catch (Exception ex) { MessageBox.Show("Ошибка выполнения SQL-запроса " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); }
            finally { CloseConnection(); }
        }

        //Заполнение DataGrid по организациям
        public DataGrid FillOrgsForAdmin(DataGrid dG)
        {
            OpenConnection();
            string query = "SELECT organization.id as Id, organization.name as Организация FROM organization";
            DataTable dt = SelectData(query);
            dG.ItemsSource = dt.DefaultView;
            CloseConnection();
            return dG;
        }

        //Сохранение новой организации
        public void SaveNewOrg(string orgName)
        {
            try
            {
                OpenConnection();

                // Проверка на отсутствие такой же организации
                string checkExistenceQuery = $"SELECT COUNT(*) FROM organization WHERE name = '{orgName}'";
                int count = Convert.ToInt32(SelectData(checkExistenceQuery).Rows[0][0]);

                if (count > 0)
                {
                    MessageBox.Show("Организация с таким названием уже существует.");
                    return;
                }

                // Сохранение формы данных в БД
                string addModuleQuery = $"INSERT INTO organization (name) VALUES ('{orgName}')";
                ExecuteNonQuery(addModuleQuery);

                MessageBox.Show("Организация успешно сохранена.", "Успешно", MessageBoxButton.OK, MessageBoxImage.None);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении данных: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.None);
            }
            finally
            {
                CloseConnection();
            }
        }

        //Получение данных об организации
        public void GetOrgById(int id, out string orgName)
        {
            OpenConnection();
            string query = $"SELECT name FROM organization WHERE id = {id}";
            DataTable dt = SelectData(query);
            orgName = dt.Rows[0]["name"].ToString();
            CloseConnection();
        }

        //Редактирование организации
        public void EditOrgs(int id, string name)
        {
            OpenConnection();
            try
            {
                string query = $"UPDATE organization SET name = '{name}' WHERE id = {id}";
                ExecuteNonQuery(query);
                MessageBox.Show("Организация успешно отредактирована", "Успешно", MessageBoxButton.OK, MessageBoxImage.None);
            }
            catch (Exception ex) { MessageBox.Show("Ошибка выполнения SQL-запроса " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); }
            finally { CloseConnection(); }
        }

        //Удаление пользователя
        public void DeleteOrgs(int id)
        {
            OpenConnection();
            try
            {
                string query = $"DELETE FROM organization WHERE id = {id}";
                ExecuteNonQuery(query);
                MessageBox.Show("Организация успешно удалена", "Успешно", MessageBoxButton.OK, MessageBoxImage.None);
            }
            catch (Exception ex) { MessageBox.Show("Ошибка выполнения SQL-запроса " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); }
            finally { CloseConnection(); }
        }

        //Заполнение DataGrid по культурам
        public DataGrid FillCulturesForAdmin(DataGrid dG)
        {
            OpenConnection();
            string query = "SELECT id as Id, culture_name as Культура FROM cultures";
            DataTable dt = SelectData(query);
            dG.ItemsSource = dt.DefaultView;
            CloseConnection();
            return dG;
        }

        //Получение данных о культуре
        public void GetCultureById(int id, out string name)
        {
            OpenConnection();
            string query = $"SELECT culture_name FROM cultures WHERE id = {id}";
            DataTable dt = SelectData(query);
            name = dt.Rows[0]["culture_name"].ToString();
            CloseConnection();
        }

        //Редактирование культуры
        public void EditCultures(int id, string name)
        {
            OpenConnection();
            try
            {
                string query = $"UPDATE cultures SET culture_name = '{name}' WHERE id = {id}";
                ExecuteNonQuery(query);
                MessageBox.Show("Культура успешно отредактирована", "Успешно", MessageBoxButton.OK, MessageBoxImage.None);
            }
            catch (Exception ex) { MessageBox.Show("Ошибка выполнения SQL-запроса " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); }
            finally { CloseConnection(); }
        }

        //Удаление культуры
        public void DeleteCultures(int id)
        {
            OpenConnection();
            try
            {
                string query = $"DELETE FROM cultures WHERE id = {id}";
                ExecuteNonQuery(query);
                MessageBox.Show("Культура успешно удалена", "Успешно", MessageBoxButton.OK, MessageBoxImage.None);
            }
            catch (Exception ex) { MessageBox.Show("Ошибка выполнения SQL-запроса " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); }
            finally { CloseConnection(); }
        }

        //Сохранение новой культуры
        public void SaveNewCultures(string cultName)
        {
            try
            {
                OpenConnection();

                // Проверка на отсутствие такой же культуры
                string checkExistenceQuery = $"SELECT COUNT(*) FROM cultures WHERE culture_name = '{cultName}'";
                int count = Convert.ToInt32(SelectData(checkExistenceQuery).Rows[0][0]);

                if (count > 0)
                {
                    MessageBox.Show("Культура с таким названием уже существует.");
                    return;
                }

                // Сохранение формы данных в БД
                string addModuleQuery = $"INSERT INTO cultures (culture_name) VALUES ('{cultName}')";
                ExecuteNonQuery(addModuleQuery);

                MessageBox.Show("Культура успешно сохранена.", "Успешно", MessageBoxButton.OK, MessageBoxImage.None);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении данных: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                CloseConnection();
            }
        }

        //Метод для DataGrid по объему выполненных работ
        public void DisplayData(string selectedOrganization, System.Windows.Controls.DataGrid dataGrid)
        {
            try
            {
                OpenConnection();

                // Получаем ID организации по её имени
                string orgIdQuery = "SELECT id FROM organization WHERE name = @organizationName";

                using (NpgsqlCommand orgIdCmd = new NpgsqlCommand(orgIdQuery, connection))
                {
                    orgIdCmd.Parameters.AddWithValue("@organizationName", selectedOrganization);
                    int organizationId = Convert.ToInt32(orgIdCmd.ExecuteScalar());

                    // Получаем формы для заполнения для данной организации, включая сведения о выращиваемой культуре и стадии
                    string formsQuery = "SELECT forms_to_fill_out.id as Id, stage.name, cultures.culture_name, forms_to_fill_out.values, to_char(forms_to_fill_out.date_filling, 'yyyy-mm-dd') " +
                                        "FROM forms_to_fill_out " +
                                        "JOIN cultures ON forms_to_fill_out.culture_id = cultures.id " +
                                        "JOIN stage ON forms_to_fill_out.stage_id = stage.id " +
                                        "WHERE forms_to_fill_out.org_id = @organizationId";

                    using (NpgsqlCommand formsCmd = new NpgsqlCommand(formsQuery, connection))
                    {
                        formsCmd.Parameters.AddWithValue("@organizationId", organizationId);

                        DataTable formsTable = new DataTable();
                        formsTable.Load(formsCmd.ExecuteReader());

                        // Установка источника данных для DataGrid
                        dataGrid.ItemsSource = formsTable.DefaultView;
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show("Ошибка выполнения SQL-запроса " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        //Метод возвращает ID названия культуры
        public int GetStageIdByName(string stage)
        {
            string query = $"SELECT id FROM stage WHERE name = '{stage}'";
            DataTable result = SelectData(query);
            return result.Rows.Count > 0 ? (int)result.Rows[0]["Id"] : -1; // Возвращает id наименования культуры. В противном случае ставит -1
        }

        //Метод для выпадающего списка стадий
        public void FillStageComboBox(ComboBox comboBox)
        {
            try
            {
                OpenConnection();

                string query = "SELECT name FROM stage";

                using (NpgsqlCommand cmd = new NpgsqlCommand(query, connection))
                {
                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string stage = reader["name"].ToString();
                        comboBox.Items.Add(stage);
                    }

                    reader.Close();
                }
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show("Ошибка выполнения SQL-запроса " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public void GetFilledDataForEdit(int id, out string org, out string culture, out string stage, out string value)
        {
            OpenConnection();
            string query = "SELECT organization.name as Org, stage.name as Stages, cultures.culture_name as Culture, forms_to_fill_out.values as Value " +
                                        "FROM forms_to_fill_out " +
                                        "JOIN cultures ON forms_to_fill_out.culture_id = cultures.id " +
                                        "JOIN stage ON forms_to_fill_out.stage_id = stage.id " +
                                        "JOIN organization ON forms_to_fill_out.org_id = organization.id " +
                                        $"WHERE forms_to_fill_out.id = {id}";
            DataTable result = SelectData(query);
            org = result.Rows[0]["Org"].ToString();
            culture = result.Rows[0]["Culture"].ToString();
            stage = result.Rows[0]["Stages"].ToString();
            value = result.Rows[0]["Value"].ToString();
            CloseConnection();
        }

        //Метод сохранения данных с формы в БД
        public void EditFilledData(int id, int orgId, int stageId, int cultureId, int volumeWork)
        {
            try
            {
                OpenConnection();

                // Сохранение изменений формы данных в БД
                string addModuleQuery = $"UPDATE forms_to_fill_out SET org_id = {orgId}, culture_id = {cultureId}, stage_id = {stageId}, values = {volumeWork}, date_filling = current_timestamp WHERE id = {id}";
                ExecuteNonQuery(addModuleQuery);

                MessageBox.Show("Данные успешно обновлены.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при обновлении данных: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        //Удаление культуры
        public void DeleteFilledData(int id)
        {
            OpenConnection();
            try
            {
                string query = $"DELETE FROM forms_to_fill_out WHERE id = {id}";
                ExecuteNonQuery(query);
                MessageBox.Show("Запись успешно удалена", "Успешно", MessageBoxButton.OK, MessageBoxImage.None);
            }
            catch (Exception ex) { MessageBox.Show("Ошибка выполнения SQL-запроса " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); }
            finally { CloseConnection(); }
        }

        public void GetAllFilledData(DataGrid dg)
        {
            try
            {
                OpenConnection();
                string formsQuery = "SELECT forms_to_fill_out.id as Id, organization.name as Организация, stage.name as Стадия, cultures.culture_name as Культура, forms_to_fill_out.values Объем, to_char(forms_to_fill_out.date_filling, 'yyyy-mm-dd') as Дата " +
                                        "FROM forms_to_fill_out " +
                                        "JOIN organization ON forms_to_fill_out.org_id = organization.id " +
                                        "JOIN cultures ON forms_to_fill_out.culture_id = cultures.id " +
                                        "JOIN stage ON forms_to_fill_out.stage_id = stage.id " +
                                        "ORDER BY Id";
                DataTable dT = SelectData(formsQuery);
                dg.ItemsSource = dT.DefaultView;
            }
            catch (Exception ex) { MessageBox.Show("Ошибка выполнения SQL-запроса " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); }
            finally { CloseConnection(); }
        }

        public void GetAllUsers(DataGrid dg)
        {
            try
            {
                OpenConnection();
                string formsQuery = "SELECT users.id as Id, users.login as Логин, users.name as ФИО, users.phone as Телефон, users.email as Email, organization.name as Организация, roles.role as Роль " +
                                        "FROM users " +
                                        "JOIN organization ON users.organization_id = organization.id " +
                                        "JOIN roles ON users.role_id = roles.id " +
                                        "ORDER BY Id";
                DataTable dT = SelectData(formsQuery);
                dg.ItemsSource = dT.DefaultView;
            }
            catch (Exception ex) { MessageBox.Show("Ошибка выполнения SQL-запроса " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); }
            finally { CloseConnection(); }
        }

        public void GetAllOrgs(DataGrid dg)
        {
            try
            {
                OpenConnection();
                string formsQuery = "SELECT id as Id, name as Организация " +
                                        "FROM organization " +
                                        "ORDER BY Id";
                DataTable dT = SelectData(formsQuery);
                dg.ItemsSource = dT.DefaultView;
            }
            catch (Exception ex) { MessageBox.Show("Ошибка выполнения SQL-запроса " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); }
            finally { CloseConnection(); }
        }

        public void GetAllCultures(DataGrid dg)
        {
            try
            {
                OpenConnection();
                string formsQuery = "SELECT id as Id, culture_name as Культура " +
                                        "FROM cultures " +
                                        "ORDER BY Id";
                DataTable dT = SelectData(formsQuery);
                dg.ItemsSource = dT.DefaultView;
            }
            catch (Exception ex) { MessageBox.Show("Ошибка выполнения SQL-запроса " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); }
            finally { CloseConnection(); }
        }

        public void GetAllRequests(DataGrid dg)
        {
            try
            {
                OpenConnection();
                string formsQuery = "SELECT requests.id as Id, users.name as Пользователь, to_char(requests.request_date, 'yyyy-mm-dd') as Дата, requests.request_theme as Тема, requests.request as Текст, status_request.status_name as Статус, requests.comment as Комментарий " +
                                        "FROM requests " +
                                        "JOIN users ON requests.user_id = users.id " +
                                        "JOIN status_request ON requests.status_id = status_request.id " +
                                        "ORDER BY Id";
                DataTable dT = SelectData(formsQuery);
                dg.ItemsSource = dT.DefaultView;
            }
            catch (Exception ex) { MessageBox.Show("Ошибка выполнения SQL-запроса " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); }
            finally { CloseConnection(); }
        }

        public double GetDataForInfoMainGeneralPage(DateTime dateTime)
        {
            OpenConnection();
            string query = $"SELECT COUNT(*) as Count FROM forms_to_fill_out WHERE date_filling = '{dateTime}'";
            DataTable dT = SelectData(query);
            CloseConnection();
            if (dT.Rows.Count > 0)
            {
                return Convert.ToDouble(dT.Rows[0]["Count"]);
            }
            else
            {
                return 0;
            }
        }
    }
}
