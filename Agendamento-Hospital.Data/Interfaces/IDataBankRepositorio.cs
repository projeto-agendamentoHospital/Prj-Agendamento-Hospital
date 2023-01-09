using Agendamento_Hospital.Data.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendamento_Hospital.Data.Interfaces
{
    public interface IDataBankRepositorio
    {
        public List<DataBankDto> GetAll();

        DataBankDto ListByID(int IdDadosBancarios);

        int CreateDataBank(DataBankDto dataBank);

        int UpdateDataBank(DataBankDto dataBank);

        int DeleteByID(int IdDadosBancarios);
    }
}

