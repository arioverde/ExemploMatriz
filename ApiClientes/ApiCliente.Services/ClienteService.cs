﻿using ApiCliente.Domain.Models;
using ApiCliente.Repositories.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ApiCliente.Services
{
    public class ClienteService
    {
        private readonly ClienteRepositorio _repositorio;
        public ClienteService()
        {
            _repositorio = new ClienteRepositorio();
        }
        public List<Cliente> Listar(string? nome)
        {
            try
            {
                _repositorio.AbrirConexao();
                return _repositorio.ListarClientes(nome);
            }
            finally 
            {
                _repositorio.FecharConexao();
            }
        }
        public Cliente? Obter(string cpfCliente)
        {
            try
            {
                _repositorio.AbrirConexao();
                return _repositorio.Obter(cpfCliente);
            }
            finally
            {
                _repositorio.FecharConexao();
            }
        }

        public void Atualizar(Cliente model)
        {
            try
            {
                _repositorio.AbrirConexao();
                _repositorio.Atualizar(model);
            }
            finally
            {
                _repositorio.FecharConexao();
            }
        }
        public void Deletar(string cpfCliente)
        {
            try
            {
                _repositorio.AbrirConexao();
                _repositorio.Deletar(cpfCliente);
            }
            finally
            {
                _repositorio.FecharConexao();
            }
        }
        public void Incluir(Cliente model)
        {
            try
            {
                _repositorio.AbrirConexao();
                _repositorio.Inserir(model);
            }
            finally
            {
                _repositorio.FecharConexao();
            }
        }
    }
}
