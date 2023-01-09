namespace AgendamentoHospital
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<Agendamento_Hospital.Data.Contexto.ProjetoContext>();

            builder.Services.AddScoped<
                Agendamento_Hospital.Data.Interfaces.IHospitalRespositorio,
                Agendamento_Hospital.Data.Repositorio.HospitalRepositorio >();

            builder.Services.AddScoped<
                Agendamento_Hospital.Data.Interfaces.ISpecialtyRepositorio,
                Agendamento_Hospital.Data.Repositorio.SpecialtyRepositorio>();

            builder.Services.AddScoped<
                 Agendamento_Hospital.Data.Interfaces.IBeneficiaryRepositorio,
                 Agendamento_Hospital.Data.Repositorio.BeneficiarioRepositorio>();  
            
            builder.Services.AddScoped<
                Agendamento_Hospital.Data.Interfaces.IProfessionalRepositorio,
                Agendamento_Hospital.Data.Repositorio.ProfessionalRepositorio>();
               
            builder.Services.AddScoped<
                Agendamento_Hospital.Data.Interfaces.IScheduleRepositorio,
                Agendamento_Hospital.Data.Repositorio.ScheduleRepositorio>();

            builder.Services.AddScoped<
                Agendamento_Hospital.Data.Interfaces.IDataBankRepositorio,
                Agendamento_Hospital.Data.Repositorio.DataBankRepositorio>();
                

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("MyRules", policy =>
                {
                    policy.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin();
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors("MyRules");

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}