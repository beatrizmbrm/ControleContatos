﻿using Microsoft.AspNetCore.Mvc;

namespace ControleContatos.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
    }
}
