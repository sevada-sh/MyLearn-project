using MyLearn.Application.Services;
using MyLearn.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLearn.Application.Interfaces
{
    public interface IChatRoomService
    {
        Task<Guid> CreateRoom(string connectionId);
        Task<Guid> GetRoomForConnectionId(string connectionId);
        Task SetRoomName(Guid roomId, string name);
        Task AddMessage(Guid roomId, ChatMessage message);
        Task<IEnumerable<ChatMessage>> GetMessagehistory(Guid roomId);
        Task<IReadOnlyDictionary<Guid, ChatRoom>> GetAllRooms();
    }
}
