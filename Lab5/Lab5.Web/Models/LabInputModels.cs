using System.ComponentModel.DataAnnotations;

namespace Lab5.Web.Models
{
    public class Lab1InputModel
    {
        [Required(ErrorMessage = "Поле N обов'язкове")]
        [Range(1, 1000, ErrorMessage = "N має бути від 1 до 1000")]
        public int N { get; set; }

        [Required(ErrorMessage = "Поле K обов'язкове")]
        [Range(1, 100, ErrorMessage = "K має бути від 1 до 100")]
        public int K { get; set; }
    }

    public class Lab2InputModel
    {
        [Required(ErrorMessage = "Напрямок обов'язковий")]
        [RegularExpression("[NSWEUD]", ErrorMessage = "Допустимі напрямки: N, S, W, E, U, D")]
        public char Direction { get; set; }

        [Required(ErrorMessage = "Параметр обов'язковий")]
        [Range(1, 100, ErrorMessage = "Параметр має бути від 1 до 100")]
        public int Parameter { get; set; }

        [Required(ErrorMessage = "Правила обов'язкові")]
        public string[] Rules { get; set; } = new string[6];
    }

    public class Lab3InputModel
    {
        [Required(ErrorMessage = "Кількість вершин обов'язкова")]
        [Range(1, 100, ErrorMessage = "Кількість вершин має бути від 1 до 100")]
        public int Vertices { get; set; }

        public List<(int From, int To, int Weight)> Edges { get; set; } = new();
    }
}