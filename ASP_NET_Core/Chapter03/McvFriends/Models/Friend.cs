using System;
using System.ComponentModel.DataAnnotations;
namespace McvFriends.Models
{
    public class Friend
    {
        public int id {get;set;}
        public string Name {get;set;}
        public string Email {get;set;}
        public string Mobile{get;set;}
    }
}