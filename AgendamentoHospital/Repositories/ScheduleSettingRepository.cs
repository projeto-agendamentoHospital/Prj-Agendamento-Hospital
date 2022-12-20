using AgendamentoHospital.DTO;
using System.Data;
using System.Data.SqlClient;

namespace AgendamentoHospital.Repositories
{
    public class ScheduleSettingRepository
    {
        public String ConnectionString { get; set; }


        public ScheduleSettingRepository()
        {
            this.ConnectionString = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json")
              .Build()
              .GetConnectionString("Projeto");
        }

        public void Create(ScheduleSettingDto scheduleSettingDto)
        {
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                String query = "INSERT INTO AgendamentoConfiguracao (IdHospital, IdEspecialidade, IdProfissional, DataHoraInicioAtendimento, DataHoraFinalAtendimento) " +
                    "VALUES (@idHospital, @idSpecialty, @idProfessional, @startDateHour, @finalDateHour)";

                SqlCommand command = new SqlCommand(query, connection);

                // Add valor ao comando
                /*command.Parameters.Add("@idConfig", SqlDbType.Int);
                command.Parameters["@idConfig"].Value = scheduleSettingDto.IdConfig;*/
                command.Parameters.Add("@idHospital", SqlDbType.Int);
                command.Parameters["@idHospital"].Value = scheduleSettingDto.IdHospital;
                command.Parameters.Add("@idSpecialty", SqlDbType.Int);
                command.Parameters["@idSpecialty"].Value = scheduleSettingDto.IdSpecialty;
                command.Parameters.Add("@idProfessional", SqlDbType.Int);
                command.Parameters["@idProfessional"].Value = scheduleSettingDto.IdProfessional;
                command.Parameters.Add("@startDateHour", SqlDbType.DateTime);
                command.Parameters["@startDateHour"].Value = scheduleSettingDto.StartDateHour;
                command.Parameters.Add("@finalDateHour", SqlDbType.DateTime);
                command.Parameters["@finalDateHour"].Value = scheduleSettingDto.FinalDateHour;

                //Abrindo conexão...
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public IList<ScheduleSettingDto> ListingSettingsData()
        {
            IList<ScheduleSettingDto> list = new List<ScheduleSettingDto>();

            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                String query = "SELECT IdConfiguracao, IdHospital, IdEspecialidade, IdProfissional, DataHoraInicioAtendimento, DataHoraFinalAtendimento FROM AgendamentoConfiguracao ORDER BY IdConfiguracao";

                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    //Recuperando dados...
                    ScheduleSettingDto scheduleSettingDto = new ScheduleSettingDto();
                    scheduleSettingDto.IdConfig = Convert.ToInt32(dataReader["IdConfiguracao"]);
                    scheduleSettingDto.IdHospital = Convert.ToInt32(dataReader["IdHospital"]);
                    scheduleSettingDto.IdSpecialty = Convert.ToInt32(dataReader["IdEspecialidade"]);
                    scheduleSettingDto.IdProfessional = Convert.ToInt32(dataReader["IdProfissional"]);
                    scheduleSettingDto.StartDateHour = Convert.ToDateTime(dataReader["DataHoraInicioAtendimento"]);
                    scheduleSettingDto.FinalDateHour = Convert.ToDateTime(dataReader["DataHoraFinalAtendimento"]);

                    //Adicionado o modelo da lista...
                    list.Add(scheduleSettingDto);
                }
                connection.Close();
            } // Finaliza o objeto connection

            // Retorna a lista
            return list;
        }

        public ScheduleSettingDto Query(int id)
        {
            ScheduleSettingDto scheduleSettingDto = new ScheduleSettingDto();

            var connectionString = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build()
                .GetConnectionString("Projeto");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String query = "SELECT IdConfiguracao, IdHospital, IdEspecialidade, IdProfissional, DataHoraInicioAtendimento, DataHoraFinalAtendimento WHERE IdConfiguracao = @idConfig";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add("@idConfig", SqlDbType.Int);
                command.Parameters["@idConfig"].Value = id;

                connection.Open();

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    //Recuperando dados
                    scheduleSettingDto.IdConfig = (int)dataReader["IdConfiguracao"];
                    scheduleSettingDto.IdHospital = (int)dataReader["IdHospital"];
                    scheduleSettingDto.IdSpecialty = (int)dataReader["IdEspecialidade"];
                    scheduleSettingDto.IdProfessional = (int)dataReader["IdProfissional"];
                    scheduleSettingDto.StartDateHour = (DateTime)dataReader["DataHoraInicioAtendimento"];
                    scheduleSettingDto.FinalDateHour = (DateTime)dataReader["DataHoraFinalAtendimento"];
                }
                connection.Close();
            }
            return scheduleSettingDto;
        }

    }
}