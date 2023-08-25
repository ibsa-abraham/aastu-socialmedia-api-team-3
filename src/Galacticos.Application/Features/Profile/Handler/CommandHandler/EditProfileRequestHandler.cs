using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErrorOr;
using Galacticos.Application.DTOs.Profile;
using Galacticos.Application.Features.Profile.Request.Commands;
using Galacticos.Application.Persistence.Contracts;
using MediatR;
using Galacticos.Domain.Errors;
using AutoMapper;
using Galacticos.Domain.Entities;

namespace Galacticos.Application.Features.Profile.Handler.CommandHandler
{
    public class EditProfileRequestHandler : IRequestHandler<EditProfileRequest, ErrorOr<ProfileResponseDTO>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        
        public EditProfileRequestHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public Task<ErrorOr<ProfileResponseDTO>> Handle(EditProfileRequest request, CancellationToken cancellationToken)
        {
            var user =  _userRepository.GetUserById(request.UserId);
            if (user == null)
            {
                return Task.FromResult<ErrorOr<ProfileResponseDTO>>(Errors.User.UserNotFound);
            }
            var userToEdit = _mapper.Map(request.EditProfileRequestDTO, user);
            var editedUser = _userRepository.EditUser(userToEdit);
            var profileResponseDTO = _mapper.Map<ProfileResponseDTO>(editedUser);
            return Task.FromResult<ErrorOr<ProfileResponseDTO>>(profileResponseDTO);
        }
    }
}