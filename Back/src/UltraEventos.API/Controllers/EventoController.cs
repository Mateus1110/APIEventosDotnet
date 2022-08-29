using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UltraEventos.API.Models;

namespace UltraEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {

        public IEnumerable<Evento> _evento = new Evento[] {
            new Evento() {
                EventoId = 1,
                Tema = "TEMAAAAA",
                Local = "Belo Horizonte",
                Lote = "1",
                QtdPessoas = 250,
                DataEvento = DateTime.Now.AddDays(2).ToString(),
                imagemURL = "imagem.url"
            },
            new Evento() {
                EventoId = 2,
                Tema = "TEMAAAAA222",
                Local = "Belo Horizonte",
                Lote = "2",
                QtdPessoas = 220,
                DataEvento = DateTime.Now.AddDays(2).ToString(),
                imagemURL = "imagem2.url"
            }
        };
        public EventoController()
        {

        }

        [HttpGet]
        public IEnumerable<Evento> Get() {
            return _evento;
        }

        [HttpGet("{id}")]
        public IEnumerable<Evento> GetById(int id) {
            return _evento.Where(evento => evento.EventoId == id);
        }

        [HttpPost]
        public string Post()
        {
            return "value Post";
        }

        [HttpPut ("{id}")]
        public string Put(int id)
        {
            return $"put com id = {id}";
        }
        
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return $"delete com id = {id}";
        }
    }
}
