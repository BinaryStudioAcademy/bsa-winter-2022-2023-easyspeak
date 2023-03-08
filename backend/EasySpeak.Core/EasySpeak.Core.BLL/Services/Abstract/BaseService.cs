using AutoMapper;
using EasySpeak.Core.DAL.Context;

namespace EasySpeak.Core.BLL.Services
{
    public abstract class BaseService
    {
        private protected readonly EasySpeakCoreContext _context;
        private protected readonly IMapper _mapper;

        public BaseService(EasySpeakCoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
