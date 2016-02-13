using WebAPIdemo.DataStore;

namespace WebAPIdemo.Controllers.ViewModels
{
    /// <summary>
    /// Person ViewModel
    /// </summary>
    public class Person : Entity {
        
        public Person(string fullName) : this() {
            FullName = fullName;
        }
        
        public Person() {
        }
        
        public string FullName { get; set; }
        
        public int Age { get; set; }
    }
    
}