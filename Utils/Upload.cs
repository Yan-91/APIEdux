using API_Edux.Domains;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace API_Edux.Utils
{
    public static class Upload
    {
        public static string Local(IFormFile File)
        {

            var nomeArquivo = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(File.FileName);
            var caminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), @"wwwRoot\upload\imagens", nomeArquivo);

            using var streamImagem = new FileStream(caminhoArquivo, FileMode.Create);

            File.CopyTo(streamImagem);

            return  "http://localhost:58611/upload/imagens/" + nomeArquivo;
        }

        internal static object Local(string imagem)
        {
            throw new NotImplementedException();
        }
    }
}
