using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Globalization;
using Loja.Models;

namespace Loja.Controllers;
// Controlador responsável pelas operações de CRUD para a entidade Property
public class ViewsProjetoController : Controller
{
    // Método para exibir a view de criação de uma nova instância de Property
    public IActionResult Create()
    {
        return View();
    }
    // Método chamado quando os dados do formulário de criação são submetidos
    [HttpPost]
    public IActionResult Create(Property a)
    {
        // Instancia um objeto Repository para acessar os métodos de persistência de dados
        Repository ar = new Repository();

        // Chama o método Inserir para adicionar a nova instância de Property
        ar.Inserir(a);

        // Redireciona para a ação "Read" para exibir todas as instâncias de Property
        return RedirectToAction("Read");
    }

    // Método para exibir a view que lista todas as instâncias de Property
    public IActionResult Read()
    {
        // Instancia um objeto Repository para acessar os métodos de leitura de dados
        Repository ar = new Repository();

        // Retorna a view com a lista de todas as instâncias de Property
        return View(ar.Listar());
    }

    // Método para exibir a view de atualização de uma instância de Property
    public IActionResult Update(int Id)
    {
        // Instancia um objeto Repository para acessar os métodos de persistência de dados
        Repository ar = new Repository();

        // Retorna a view com os dados da instância de Property especificada pelo Id
        return View(ar.BuscaPorId(Id));
    }

    // Método chamado quando os dados do formulário de atualização são submetidos
    [HttpPost]
    public IActionResult Update(Property a)
    {
        // Instancia um objeto Repository para acessar os métodos de persistência de dados
        Repository ar = new Repository();

        // Chama o método Editar para atualizar a instância de Property
        ar.Editar(a);

        // Redireciona para a ação "Read" para exibir todas as instâncias de Property após a atualização
        return RedirectToAction("Read");
    }

    // Método para excluir uma instância de Property
    public IActionResult Delete(int Id)//Usando O "/Alunos/Excluir?Id=@a.IdAlunos" DE Listar EM Views
    {
        // Instancia um objeto Repository para acessar os métodos de persistência de dados
        Repository ar = new Repository();

        // Chama o método Deletar para excluir a instância de Property pelo Id fornecido
        ar.Deletar(Id);

        // Redireciona para a ação "Read" para exibir todas as instâncias de Property após a exclusão
        return RedirectToAction("Read");//APÓS A FUNÇÃO SER EXECUTADA SERA REDIRECIONADA PARA Listar EM Views
    }
}