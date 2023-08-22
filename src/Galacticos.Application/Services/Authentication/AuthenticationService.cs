using Galacticos.Application.Common.Interface.Authentication;
using Galacticos.Application.Persistence.Contracts;
using Galacticos.Domain.Entities;

namespace Galacticos.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService{

    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public AuthenticationResult Register(string firstName, string lastName, string username, string password, string email){

        var identifier = (username ?? email) ?? throw new Exception("Username or Email is required");

        if (identifier is not null && _userRepository.GetUserByIdentifier(identifier) is not null)
            throw new Exception("Username or Email is already taken");

        User user = new() { FirstName = firstName, LastName = lastName, UserName = username, Email = email, Password = password};
        

        _userRepository.AddUser(user);

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token
        );
    }

    public AuthenticationResult Login(string identifier, string password){

        if(identifier is null)
            throw new Exception("Username or Email is required");
        
        if(_userRepository.GetUserByIdentifier(identifier) is not User user)
            throw new Exception("User with given Username or Password does not exist");
        
        if(user.Password != password)
            throw new Exception("User with given Username or Password does not exist");


        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token
        );
    }
}