using System;
using System.Collections.Generic;
using System.Configuration;
using DriverAssigner.Models;
using ServiceStack.DesignPatterns.Model;
using ServiceStack.Redis;
using ServiceStack.Redis.Generic;

namespace DriverAssigner.Domain {
    public class DriverRepository {
        IRedisTypedClient<Driver> redisTypedClient;
        string KEY = "drivers";

        public DriverRepository() {
            var uri = new Uri(ConfigurationManager.AppSettings["REDISTOGO_URL"]);
            redisTypedClient = new RedisClient(uri).As<Driver>();
        }

        public IList<Driver> GetAll() {
            IList<Driver> drivers = redisTypedClient.Lists[KEY].GetAll();
            ((RedisClient)redisTypedClient.RedisClient).Quit();
            return drivers;
        }

        public void Push(Driver driver) {
            redisTypedClient.Lists[KEY].Push(driver);
            ((RedisClient)redisTypedClient.RedisClient).Quit();
        }

        public Driver Pop() {
            Driver driver = redisTypedClient.Lists[KEY].Pop();
            ((RedisClient)redisTypedClient.RedisClient).Quit();
            return driver;
        }
    }
}