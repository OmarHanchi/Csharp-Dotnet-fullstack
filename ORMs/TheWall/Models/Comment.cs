#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TheWall.Models;
public class Comment
{
    [Key]
    public int CommentId {get;set;}
    [Required(ErrorMessage = "Comment is required")]
    public string MyComment {get;set;}
    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;
    public int UserId {get;set;}
    public User? Commenter {get;set;}
    public int MessageId {get;set;}
    public Message? MessageCommentedOn {get;set;}
}