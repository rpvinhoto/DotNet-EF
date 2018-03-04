using AutoMapper;
using ProjetoLivraria.Dominio.Entidades;
using ProjetoLivraria.MVC.ViewModels;

namespace ProjetoLivraria.MVC.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<LivroViewModel, Livro>();
            CreateMap<EditoraViewModel, Editora>();
            CreateMap<CategoriaViewModel, Categoria>();
        }
    }
}