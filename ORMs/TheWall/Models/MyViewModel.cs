#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace TheWall.Models;
public class MyViewModel
{
    public User LoggedInUser {get;set;}
    public Message NewMessage {get;set;}
    public Comment NewComment {get;set;}
    public List<Message> AllMessages {get;set;}
}