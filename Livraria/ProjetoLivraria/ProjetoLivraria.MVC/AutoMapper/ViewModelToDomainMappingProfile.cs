using AutoMapper;
using ProjetoLivraria.Dominio.Entidades;
using ProjetoLivraria.MVC.ViewModels;

namespace ProjetoLivraria.MVC.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<LivroViewModel, Livro>();
            CreateMap<EditoraViewModel, Editora>();
            CreateMap<CategoriaViewModel, Categoria>();
        }
    }
}