using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgendaTelefonica.Models
{
    public abstract class GenericAbstractEntidades<TEntity, TKey> where TEntity : class
    {
        #region ABSTRAÇÃO
        //Criando classe abstrata para reaproveitamento do código e sobscrever o método para qualquer entidade
        public abstract List<TEntity> GetAll();
        public abstract TEntity GetById(TKey id);
        public abstract void Cadastrar(TEntity entity);
        public abstract void Update(TEntity entity);
        public abstract void Deletar(TEntity entity);
        public abstract void DeletarById(TKey entity);
        #endregion

    }
}