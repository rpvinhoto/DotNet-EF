using AutoMapper;
using ProjetoLivraria.Dominio.Entidades;
using ProjetoLivraria.MVC.ViewModels;

namespace ProjetoLivraria.MVC.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<Livro, LivroViewModel>();
            CreateMap<Editora, EditoraViewModel>();
            CreateMap<Categoria, CategoriaViewModel>();
        }
    }
}