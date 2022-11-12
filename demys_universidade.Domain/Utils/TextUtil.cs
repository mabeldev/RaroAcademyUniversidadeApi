﻿using demys_universidade.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demys_universidade.Domain.Utils
{
    public static class TextUtil
    {
        public static int GetStatusCode(this StatusException status)
        {
            switch (status)
            {
                case StatusException.FormatoIncorreto:
                case StatusException.Obrigatoriedade:
                    return 400;
                case StatusException.NaoAutorizado:
                    return 401;
                case StatusException.AcessoProibido:
                    return 403;
                case StatusException.NaoEncontrado:
                    return 404;
                case StatusException.NaoProcessado:
                    return 422;
                default:
                    return 500;
            }
        }
    }
}