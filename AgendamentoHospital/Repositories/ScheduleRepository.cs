using AgendamentoHospital.DTO;
using System.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Data;

namespace AgendamentoHospital.Repositories
{
    public class ScheduleRepository
    {
        public String ConnectionString { get; set; }

        public ScheduleRepository()
        {
            this.ConnectionString = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build()
               .GetConnectionString("Projeto");
        }

        public void CreateSchedule(ScheduleDto scheduleDto)
        {
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                String query = "INSERT INTO Agendamento (idHospital, idEspecialidade, idProfissional, DataHoraAgendamento, idBeneficiario, Ativo) " +
                    "VALUES (@idHospital, @idSpecialty, @idProfessional, @dateHourSchedule, @idBeneficiary, @isActiveSchedule)";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.Add("@idHospital", SqlDbType.Int);
                command.Parameters["@idHospital"].Value = scheduleDto.IdHospital;
                command.Parameters.Add("@idSpecialty", SqlDbType.Int);
                command.Parameters["@idSpecialty"].Value = scheduleDto.IdSpecialty;
                command.Parameters.Add("@idProfessional", SqlDbType.Int);
                command.Parameters["@idProfessional"].Value = scheduleDto.IdProfessional;
                command.Parameters.Add("@dateHourSchedule", SqlDbType.DateTime);
                command.Parameters["@dateHourSchedule"].Value = scheduleDto.DateHourSchedule;
                command.Parameters.Add("@idBeneficiary", SqlDbType.Int);
                command.Parameters["@idBeneficiary"].Value = scheduleDto.IdBeneficiary;
                command.Parameters.Add("@isActiveSchedule", SqlDbType.Bit);
                command.Parameters["@isActiveSchedule"].Value = scheduleDto.IsActiveSchedule;

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public IList<ScheduleDto> ListingSchedules()
        {
            IList<ScheduleDto> listSchedules = new List<ScheduleDto>();

            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                String query = "SELECT idAgendamento, idHospital, idEspecialidade, idProfissional, DataHoraAgendamento, idBeneficiario, Ativo FROM Agendamento ORDER BY idAgendamento";

                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    ScheduleDto scheduleDto = new ScheduleDto();
                    scheduleDto.IdSchedule = Convert.ToInt32(dataReader["idAgendamento"]);
                    scheduleDto.IdHospital = Convert.ToInt32(dataReader["idHospital"]);
                    scheduleDto.IdSpecialty = Convert.ToInt32(dataReader["idEspecialidade"]);
                    scheduleDto.IdProfessional = Convert.ToInt32(dataReader["idProfissional"]);
                    scheduleDto.DateHourSchedule = Convert.ToDateTime(dataReader["DataHoraAgendamento"]);
                    scheduleDto.IdBeneficiary = Convert.ToInt32(dataReader["idBeneficiario"]);
                    scheduleDto.IsActiveSchedule = Convert.ToBoolean(dataReader["Ativo"]);

                    listSchedules.Add(scheduleDto);
                }
                connection.Close();
            }

            return listSchedules;
        }
        //OK

        public ScheduleDto Query(int id)
        {
            ScheduleDto scheduleDto = new ScheduleDto();

            var connectionString = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build()
                .GetConnectionString("Projeto");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String query = "SELECT idAgendamento, idHospital, idEspecialidade, idProfissional, DataHoraAgendamento, idBeneficiario, Ativo FROM Agendamento WHERE idAgendamento = @idSchedule";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add("@idSchedule", SqlDbType.Int);
                command.Parameters["@idSchedule"].Value = id;

                connection.Open();

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    //Recuperando dados
                    scheduleDto.IdSchedule = (int)dataReader["idAgendamento"];
                    scheduleDto.IdHospital = (int)dataReader["idHospital"];
                    scheduleDto.IdSpecialty = (int)dataReader["idEspecialidade"];
                    scheduleDto.IdProfessional = (int)dataReader["idProfissional"];
                    scheduleDto.DateHourSchedule = (DateTime)dataReader["DataHoraAgendamento"];
                    scheduleDto.IdBeneficiary = (int)dataReader["idBeneficiario"];
                    scheduleDto.IsActiveSchedule = (bool)dataReader["Ativo"];
                }
                connection.Close();
            }
            return scheduleDto;
        }

        public void Update(ScheduleDto scheduleDto)
        {
            var connectionString = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build()
                .GetConnectionString("Projeto");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String query = "UPDATE Agendamento SET idHospital = @idHospital, idEspecialidade = @idSpecialty, " +
                    "idProfissional = @idProfessional, DataHoraAgendamento = @dateHourSchedule, idBeneficiario = @idBeneficiary, Ativo = @isActiveSchedule " +
                    "WHERE idAgendamento = @idSchedule";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.Add("@idSchedule", SqlDbType.Int);
                command.Parameters["@idSchedule"].Value = scheduleDto.IdSchedule;
                command.Parameters.Add("@idHospital", SqlDbType.Int);
                command.Parameters["@idHospital"].Value = scheduleDto.IdHospital;
                command.Parameters.Add("@idSpecialty", SqlDbType.Int);
                command.Parameters["@idSpecialty"].Value = scheduleDto.IdSpecialty;
                command.Parameters.Add("@idProfessional", SqlDbType.Int);
                command.Parameters["@idProfessional"].Value = scheduleDto.IdProfessional;
                command.Parameters.Add("@dateHourSchedule", SqlDbType.DateTime);
                command.Parameters["@dateHourSchedule"].Value = scheduleDto.DateHourSchedule;
                command.Parameters.Add("@idBeneficiary", SqlDbType.Int);
                command.Parameters["@idBeneficiary"].Value = scheduleDto.IdBeneficiary;
                command.Parameters.Add("@isActiveSchedule", SqlDbType.Bit);
                command.Parameters["@isActiveSchedule"].Value = scheduleDto.IsActiveSchedule;

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void Delete(int id)
        {
            var connectionString = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build()
                .GetConnectionString("Projeto");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String query = "DELETE Agendamento WHERE idAgendamento = @idSchedule";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.Add("@idSchedule", SqlDbType.Int);
                command.Parameters["@idSchedule"].Value = id;

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}

