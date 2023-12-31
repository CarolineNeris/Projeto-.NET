﻿using System.Text;
namespace RoadMapApp;

public class AnaCaroline
{
    public static string Name => "Ana Caroline";
      public static List<(string, int)> Skills => new List<(string, int)>{
            ("Fundamentos de C#", 3),
            ("Habilidades Gerais de Desenvolvimento",3),
            ("Fundamentos de Banco de Dados",2),
            ("Habilidades Gerais com Git e Github", 4),
            ("Fundamentos de Comunicação com API Clients", 1),
            ("Conhecimento de Bibliotecas do lado do Cliente", 1)
         };
      public static string View(){
            var sb = new StringBuilder();
            sb.AppendLine($"Nome: {Name}");
            sb.AppendLine();
            sb.AppendLine("Habilidades:");
            foreach(var skill in Skills){
                  sb.AppendLine($"\t{skill.Item1} - {skill.Item2} estrelas");
            }
            var sum = Skills.Sum(x => x.Item2);
            sb.AppendLine();
            sb.AppendLine($"Total de estrelas: {sum}");
            return sb.ToString();
      }

}
