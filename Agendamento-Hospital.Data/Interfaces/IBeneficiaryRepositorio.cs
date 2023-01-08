﻿using Agendamento_Hospital.Data.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendamento_Hospital.Data.Interfaces
{
    public interface IBeneficiaryRepositorio
    {
        public List<BeneficiarioDto> beneficiariosDtos();

        BeneficiarioDto ListarBeneficiariosPorId(int IdBeneficiario);

        int Cadastrar(BeneficiarioDto CreateBeneficiary);

        int Atualizar(BeneficiarioDto Atualizar);

        int Excluir(int IdBeneficiario);
    }
}