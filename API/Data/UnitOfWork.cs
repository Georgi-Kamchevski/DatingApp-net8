using System;
using API.Interfaces;

namespace API.Data;

public class UnitOfWork(DataContext context, ILikesRepository likesRepository,
 IMessageRepository messageRepository, IUserRepository userRepository, IPhotoRepository photoRepository ) : IUnitOfWork
{
    public IUserRepository UserRepository => userRepository;

    public IMessageRepository MessageRepository => messageRepository;

    public ILikesRepository LikesRepository => likesRepository;

    public IPhotoRepository PhotoRepository => photoRepository;

    public async Task<bool> Complete()
    {
        return await context.SaveChangesAsync()>0;
    }

    public bool HasChanges()
    {
        return context.ChangeTracker.HasChanges();
    }
}
