using ControleContatos.Data;
using ControleContatos.Models;

namespace ControleContatos.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorios
    {
        private readonly BancoContext _bancoContext;

        // Corrigir o construtor
        public ContatoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public ContatoModel ListaPorId(int id)
        {
            return _bancoContext.Contatos.FirstOrDefault(x=> x.Id == id);
        }
        public List<ContatoModel> BuscarTodos()
        {
            return _bancoContext.Contatos.ToList();
        }
        public ContatoModel Adicionar(ContatoModel contato)
        {
            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();

            return contato;
        }
        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel contatoDB=ListaPorId(contato.Id);
            if (contatoDB == null) throw new Exception("houve erro ao atualizar contato");

            contatoDB.Nome = contato.Nome;
            contatoDB.Email = contato.Email;
            contatoDB.Telefone = contato.Telefone;


            _bancoContext.Contatos.Update(contatoDB);
            _bancoContext.SaveChanges();

            return contatoDB;
        }
    }
}
