using AutoMapper;
using OmegaInc.MultiPorpose.Data.Example;
using OmegaInc.MultiPorpose.WEB.ViewModels.Example;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OmegaInc.MultiPorpose.WEB.AutoMapper
{
    public class AutoMapperManager
    {
        #region Properties
        private static readonly Lazy<AutoMapperManager> _instance
            = new Lazy<AutoMapperManager>(() =>
            {
                return new AutoMapperManager();
            });

        public static AutoMapperManager Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        private MapperConfiguration _config;

        public IMapper Mapper
        {
            get
            {
                return _config.CreateMapper();
            }
        }
        #endregion

        private AutoMapperManager()
        {
            _config = new MapperConfiguration((cfg) =>
            {

                #region User
                cfg.CreateMap<User, UserIndexViewModel>();
                cfg.CreateMap<UserIndexViewModel, User>();

                cfg.CreateMap<User, UserViewModel>();
                cfg.CreateMap<UserViewModel, User>();
                #endregion
            }
            );

        }
    }
}