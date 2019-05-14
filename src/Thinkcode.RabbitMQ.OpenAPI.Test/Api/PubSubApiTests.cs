/* 
 * Rabbitmq Http API
 *
 * This is the OpenAPI specification of the RabbitMQ HTTP API. For more information, please refer to [HTTP API](https://cdn.rawgit.com/rabbitmq/rabbitmq-management/v3.7.14/priv/www/api/index.html) official documentation.
 *
 * OpenAPI spec version: 1.0
 * Contact: carlos@adaptive.me
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using RestSharp;
using Xunit;

using Thinkcode.RabbitMQ.OpenAPI.Client;
using Thinkcode.RabbitMQ.OpenAPI.Api;
using Thinkcode.RabbitMQ.OpenAPI.Model;

namespace Thinkcode.RabbitMQ.OpenAPI.Test
{
    /// <summary>
    ///  Class for testing PubSubApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    public class PubSubApiTests : IDisposable
    {
        private PubSubApi instance;
        private const string userName = "testuser";
        private const string userPass = "testpass";
        private const string basePath = "https://mb1.bus.adaptive.me/rabbitmq/api";
        private const string vhost = "test";
        private const string exchange = "shared.exchange";
        private const string queue = "shared.queue";
        private const string routingKey = "shared.key";

        public PubSubApiTests()
        {
            instance = new PubSubApi();
            var configuration = new Configuration()
            {
                Username = userName,
                Password = userPass,
                BasePath = basePath
            };
            instance = new PubSubApi(configuration);
        }

        public void Dispose()
        {
            // Cleanup when everything is done.
        }

        /// <summary>
        /// Test an instance of PubSubApi
        /// </summary>
        [Fact]
        public void InstanceTest()
        {
            // TODO uncomment below to test 'IsInstanceOfType' PubSubApi
            //Assert.IsType(typeof(PubSubApi), instance, "instance is a PubSubApi");
        }

        
        /// <summary>
        /// Test ConsumeMessage
        /// </summary>
        [Fact]
        public void ConsumeMessageTest()
        {
            ConsoleRunnerLogger logger = new ConsoleRunnerLogger(true);
            logger.LogMessage("Testing");
            var body = new ConsumeRequest(4, "ack_requeue_false", "auto", 50000);
            var response = instance.ConsumeMessage(vhost, queue, body);
            Assert.NotNull(response);
        }

        /// <summary>
        /// Test PublishMessage
        /// </summary>
        [Fact]
        public void PublishMessageTest()
        {
            var body = new PublishRequest(routingKey, "Payload", PublishRequest.PayloadEncodingEnum.String, new PublishProperties());
            var response = instance.PublishMessage(vhost, exchange, body);
            Assert.NotNull(response);
            Assert.True(response.Routed);
        }

        [Fact]
        public void PublishMessageWithPropertiesTest()
        {

            var body = new PublishRequest(routingKey, "Payload", PublishRequest.PayloadEncodingEnum.String, new PublishProperties("appid","correlationid","messageid",userName,2));
            var response = instance.PublishMessage(vhost, exchange, body);
            Assert.NotNull(response);
            Assert.True(response.Routed);
        }

    }

}
