using GoveeControl.Models;
using Newtonsoft.Json.Linq;

namespace GoveeControl.Json
{
    public class JsonHandler
    {
        private readonly string _path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Settings.json");

        /// <summary>
        /// Method to read a singular value from JSON
        /// </summary>
        /// <param name="key">The key to read from</param>
        /// <returns>The JSON value as a string</returns>
        public string ReadValue(string key)
        {
            JObject json = Read();

            return json[key]?.ToString() ?? string.Empty;
        }

        /// <summary>
        /// Method to write a singular value to JSON
        /// </summary>
        /// <param name="key">The key to write to</param>
        /// <param name="val">The string value to be written in JSON</param>
        public void WriteValue(string key, string val)
        {
            JObject json = Read();

            json[key] = val;

            File.WriteAllText(_path, json.ToString());
        }

        /// <summary>
        /// Method to extract all DeviceGroups from the JSON 
        /// </summary>
        /// <returns>A list of type DeviceGroup</returns>
        public List<DeviceGroup> ReadGroups()
        {
            JObject json = Read();
            JArray groups = (JArray)json["Groups"]!;

            if (groups.Count <= 0) throw new Exception("No groups found");

            List<DeviceGroup> groupsList = new();

            foreach (JObject group in groups.Cast<JObject>())
            {
                DeviceGroup tempGroup = new();
                List<GoveeDevice> tempDevices = new();
                
                int groupId = (int)group["groupId"]!;
                string groupName = (string)group["groupName"]!;

                JArray devices = (JArray)group["devices"]!;

                foreach(JObject device in devices)
                {
                    GoveeDevice tempDevice = new();

                    string deviceId = (string)device["deviceId"]!;
                    string model = (string)device["model"]!;

                    tempDevice.DeviceId = deviceId;
                    tempDevice.Model = model;

                    tempDevices.Add(tempDevice);
                }

                tempGroup.Id = groupId;
                tempGroup.GroupName = groupName;
                tempGroup.Devices = tempDevices;

                groupsList.Add(tempGroup);
            }

            return groupsList;
        }

        /// <summary>
        /// Method to add a group to the JSON file
        /// </summary>
        /// <param name="group">DeviceGroup to be added</param>
        public void WriteGroup(DeviceGroup group) 
        {
            JObject json = Read();
            JArray groups = (JArray)json["Groups"]!;
            JArray devices = new();

            foreach (GoveeDevice device in group.Devices)
            {
                JObject tempDevice = new()
                {
                    ["deviceId"] = device.DeviceId,
                    ["model"] = device.Model
                };

                devices.Add(tempDevice);
            }

            JObject newGroup = new()
            {
                ["groupId"] = group.Id,
                ["groupName"] = group.GroupName,
                ["devices"] = devices
            };

            groups.Add(newGroup);

            string updatedJson = json.ToString();
            File.WriteAllText(_path, updatedJson);
        }

        /// <summary>
        /// Method to delete a group from the JSON file
        /// </summary>
        /// <param name="id">The groupId to delete</param>
        /// <exception cref="Exception">Throws an exception if no group matches the id</exception>
        public void DeleteGroup(int id)
        {
            JObject json = Read();
            JArray groups = (JArray)json["Groups"]!;

            for (int i = 0; i < groups.Count; i++)
            {
                JObject groupObj = (JObject)groups[i];
                int groupId = (int)groupObj["groupId"]!;
                if (groupId == id)
                {
                    groups.RemoveAt(i);
                    string updatedJson = json.ToString();
                    File.WriteAllText(_path, updatedJson);
                    return;
                }
            }

            throw new Exception("Group does not exist");
        }

        /// <summary>
        /// Helper for brevity
        /// </summary>
        /// <returns>Parsed JObject representing the file</returns>
        public JObject Read()
        {
            return JObject.Parse(File.ReadAllText(_path));
        }
    }
}
