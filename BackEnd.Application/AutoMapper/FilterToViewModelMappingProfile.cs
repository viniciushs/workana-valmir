namespace BackEnd.Application.AutoMapper
{
    using BackEnd.Application.Filters;
    using BackEnd.Application.ViewModel;
    using global::AutoMapper;
    using System.Collections.Generic;
    using System.Linq;

    public class FilterToViewModelMappingProfile : Profile
    {
        public FilterToViewModelMappingProfile()
        {
            this.CreateMap<FranqueadoFilter, IEnumerable<FranqueadoViewModel>>()
                .AfterMap((src, dest) => 
                {
                    // Inclua apenas lógica para sublistas dentro do afterMap

                    //if (src.IdFuncionario.HasValue)
                    //{
                    //    foreach(var item in dest)
                    //    {
                    //        item.Funcionario = item.Funcionario.Where(f => f.IdFuncionario == src.IdFuncionario.Value).ToList();
                    //    }
                    //}

                    //if (!string.IsNullOrEmpty(src.DescricaoFuncionario))
                    //{
                    //    foreach (var item in dest)
                    //    {
                    //        item.Funcionario = item.Funcionario.Where(f => f.DescricaoFuncionario == src.DescricaoFuncionario).ToList();
                    //    }
                    //}
                });
        }
    }
}
