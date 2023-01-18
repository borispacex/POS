using POS.Application.Commons.Bases;
using POS.Application.Dtos.Provider.Request;
using POS.Application.Dtos.Provider.Response;
using POS.Infraestructure.Commons.Bases.Request;
using POS.Infraestructure.Commons.Bases.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Application.Interfaces
{
    public interface IProviderApplication
    {
        Task<BaseResponse<BaseEntityResponse<ProviderResponseDto>>> ListProviders(BaseFiltersRequest filters);
        Task<BaseResponse<ProviderResponseDto>> ProviderById(int providerId);
        Task<BaseResponse<bool>> RegisterProvider(ProviderRequestDto requestDto);
        Task<BaseResponse<bool>> EditProvider(int providerId, ProviderRequestDto requestDto);
        Task<BaseResponse<bool>> RemoveProvider(int providerId);

    }
}
