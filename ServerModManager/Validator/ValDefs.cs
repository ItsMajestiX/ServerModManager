using System.Collections.Generic;

//Put all the variables in one place
namespace ServerModManager
{
    partial class Validator
    {
        //Make enum for easier time reading code
        public enum OP_TYPE
        {
            INVALID,
            MAIN_HELP = 0,
            INSTALL = 1,
            INSTALL_HELP = -1,
            REMOVE = 2,
            REMOVE_HELP = -2,
            UPDATE = 3,
            UPDATE_HELP = -3
        }

        //Define values that can be set by command
        public bool success = false;
        public OP_TYPE opType = OP_TYPE.INVALID;

        //Ensure plugin folders are found
        //public bool pluginsExist = false;
        //public bool dependenciesExist = false;

        //For commands that need package names
        public List<string> packageNames = new List<string> { };

        //Install command
        public bool createDir = false;

        //Remove command
        public bool removeAll = false;

        //Update command
        public bool forceUpdate = false;
        public bool updateAll = false;
    }
}
