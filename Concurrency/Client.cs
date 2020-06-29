using System.Collections.Generic;
using System.Linq;

namespace Concurrency
{
  public class Client
  {   
    private Server Server;
    public List<Channel> MyChannels;
    public Channel CurrentChannel;

    public void Start()
    {
      /*Server = new Server();
      Server.Start();*/
    }

    public void CreateUser(string name)
    {
      Server.CreateUser(name);
    }

    public void Join(string channelName, User user)
    {
      Server.Join(channelName, user);
      List<Channel> allChannels = GetAllChannels();
      MyChannels = new List<Channel>();
      foreach (var channel in allChannels.Where(x => x.Name == channelName))
      {
        MyChannels.Add(channel);
      }
    }

    public void Leave()
    {
      Leave(CurrentChannel.ToString());
    }

    public void Leave(string channelName)
    {
      List<Channel> allChannels = GetAllChannels();
      foreach (var channel in allChannels.Where(x => x.Name == channelName)) MyChannels.Remove(channel);
    }

    public User WhoAmI()
    {
      return User;
    }

    public void NewNick(string newNick)
    {
      Server.UpdateNick(User, newNick);
    }

    public void Quit()
    {
      Server.Dispose();
      
    }

    public List<Channel> GetAllChannels()
    {
      return Server.GetAllChannels();
    }

    public List<User> GetAllUsers()
    {
      return Server.GetAllUsers();
    }

    public List<Channel> GetMyChannels()
    {
      return MyChannels;
    }
  }
}