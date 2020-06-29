using System.Collections.Generic;
using System.Linq;

namespace Concurrency
{
  public class User
  {
    private string userName;
    private Channel currentChannel;
    private List<Channel> myChannels;
    private Server server;

    public User(Server server)
    {
      this.server = server;
    }
    public string UserName
    {
      get { return userName; }
      set { userName = value; }
    }

    public override string ToString()
    {
      return userName;
    }

    public void CreateNewChannel(string newChannel)
    {
      server.CreateChannel(newChannel);
    }

    public void Join(string channelName)
    {
      server.Join(channelName, this);
      AddChannelToMyChannels(channelName);

    }

    private void AddChannelToMyChannels(string channelName)
    {
      throw new System.NotImplementedException();
    }

    public void Leave()
    {
      Leave(currentChannel.ToString());
    }

    public void Leave(string channelName)
    {
      Client.Leave(channelName, this);
    }

    public User WhoAmI()
    {
      return this;
    }
  }
}