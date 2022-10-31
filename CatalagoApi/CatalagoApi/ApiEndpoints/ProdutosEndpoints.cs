using CatalagoApi.Context;
using CatalagoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalagoApi.ApiEndpoints
{
    public static class ProdutosEndpoints
    {
        public static void MapProdutosEndpoints(this WebApplication app)
        {
            app.MapPost("/produtos", async (Produto produto, AppDbContext db) =>
            {
                db.Produtos.Add(produto);
                await db.SaveChangesAsync();

                return Results.Created($"/categorias/{produto.ProdutoId}", produto);
            });

            app.MapGet("/produtos", async (AppDbContext db) =>
                await db.Produtos.ToArrayAsync()).WithTags("Produtos").RequireAuthorization();

            app.MapGet("/produtos/{id:int}", async (int id, AppDbContext db) =>
            {
                return await db.Produtos.FindAsync(id)
                is Produto produto
                ? Results.Ok(produto)
                : Results.NotFound();

            });

            app.MapPut("/produtos/{id:int}", async (int id, AppDbContext db, Produto produto) =>
            {
                if (produto.ProdutoId != id)
                    return Results.BadRequest();

                var produtoDB = await db.Produtos.FindAsync(id);

                if (produtoDB is null) return Results.NotFound();

                produtoDB.Nome = produto.Nome;
                produtoDB.Descricao = produto.Descricao;
                produtoDB.Preco = produto.Preco;
                produtoDB.Imagem = produto.Imagem;
                produtoDB.DataCompra = produto.DataCompra;
                produtoDB.Estoque = produto.Estoque;
                produtoDB.CategoriaId = produto.CategoriaId;

                await db.SaveChangesAsync();
                return Results.Ok(produtoDB);
            });

            app.MapDelete("/produtos/{id:int}", async (int id, AppDbContext db) =>
            {
                var produto = await db.Produtos.FindAsync(id);

                if (produto is null)
                    return Results.NotFound();

                db.Produtos.Remove(produto);
                await db.SaveChangesAsync();

                return Results.NoContent();
            });

        }
    }
}
