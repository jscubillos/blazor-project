using Blazor.Project.Application.Hospitals.Queries.Common;
using Blazor.Project.Application.Interfaces;

namespace Blazor.Project.Application.Hospitals.Queries.Get;

public interface IGetHospitalQuery : IQuery<GetHospitalInputModel, GetHospitalOutputModel>;