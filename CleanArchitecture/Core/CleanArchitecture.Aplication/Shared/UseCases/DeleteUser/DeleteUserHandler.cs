using AutoMapper;
using CleanArchitecture.Aplication.UseCases.DeleteUser;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using MediatR;

namespace CleanArchitecture.Aplication.UseCases.DeleteUser;
public class DeleteUserHandler : IRequestHandler<DeleteUserRequest, DeleteUserResponse> {
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public DeleteUserHandler (IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper) {
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<DeleteUserResponse> Handle(DeleteUserRequest request, CancellationToken cancellationToken){
        var user = await _userRepository.Get(request.Id, cancellationToken);    
        if(user is null) return default;

        _userRepository.Delete(user);
        await _unitOfWork.Commit(cancellationToken);

        return _mapper.Map<DeleteUserResponse>(user);
    }
}
