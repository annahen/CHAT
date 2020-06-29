using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Concurrency;

namespace ConcurrencyTest
{
  [TestClass]
  public class ConcurrencyTest
  {
    private Client client;
    [TestInitialize]
    public void Setup()
    {
      Server server = new Server();
      client = new Client();
      server.Start();
      //client.Start();
    }

    [TestMethod]
    public void CreateChannel()
    {
      Channel channel = new Channel {Name = "test"};
      client.Join(channel.Name);
      List<Channel> allChannels = client.GetAllChannels();
      string otherName = allChannels.Find(i => i.Name == "test").ToString();
      Assert.AreEqual(channel.Name, otherName);
    }

    [TestMethod]
    public void CreateUser()
    {
      string user = "Jonatan";
      client.CreateUser(user);
      List<User> allUsers = client.GetAllUsers();
      string name = allUsers.Find(i => i.UserName == "Jonatan").ToString();
      Assert.AreEqual("Jonatan", name);
    }

    [TestMethod]
    public void UpdateNickAndCheckWhoIAm()
    {
      string user = "Jonatan";
      client.CreateUser(user);
      List<User> allUsers = client.GetAllUsers();
      string name = allUsers.Find(i => i.UserName == "Jonatan").ToString();
      Assert.AreEqual("Jonatan", name);
      client.NewNick("Sandra");
      string newName = client.WhoAmI().ToString();
      Assert.AreEqual("Sandra", newName);
    }

    [TestMethod]
    public void JoinChannelThatDoesNotExistAndLeaveChannel()
    {
      client.Join("other");
      List<Channel> allChannels = client.GetAllChannels();
      string channel = allChannels.Find(i => i.Name == "other").ToString();
      Assert.AreEqual("other", channel);

      client.Leave(channel);
      List<Channel> myChannels = client.GetMyChannels();
      Assert.IsNotNull(myChannels);
      Assert.AreNotEqual("other", null);
    }

    [TestMethod]
    public void AddAnotherClient()
    {
      string user = "Anna";
      client.CreateUser(user);
      Client client2 = new Client();
      string user2 = "Sara";
      client2.CreateUser(user2);
      List<User> allUsers = client.GetAllUsers();
      string name = allUsers.Find(i => i.UserName == "Sara").ToString();
      Assert.AreEqual("Sara", name);

      Assert.AreEqual(("Anna", "Sara"), allUsers);
    }
  }
}
