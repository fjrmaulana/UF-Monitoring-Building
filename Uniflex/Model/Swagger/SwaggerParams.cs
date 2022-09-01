using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace I_HUB.Model.Swagger
{
    public class SwaggerParams    {

        public string swagger { get; set; }
        public Info info { get; set; }
        public string host { get; set; }
        public string basePath { get; set; }
        public List<Tag> tags { get; set; }
        public List<string> schemes { get; set; }
        public Paths paths { get; set; }
        public SecurityDefinitions securityDefinitions { get; set; }
        public Definitions definitions { get; set; }
        public ExternalDocs externalDocs { get; set; }

        public SwaggerParams() { }

        public static SwaggerParams GetForDataSource(string url_,string basePhats)
        {
            SwaggerParams s = new SwaggerParams {
                swagger = "2.0",
                info = new Info
                {
                    description = "This is a sample server Petstore server.  You can find out more about Swagger at [http://swagger.io](http://swagger.io) or on [irc.freenode.net, #swagger](http://swagger.io/irc/).  For this sample, you can use the api key `special-key` to test the authorization filters.",
                    version = "1.0.6",
                    title = "Swagger I-HUB",
                    contact = new Contact { email = "apiteam@swagger.io" },
                    license = new License { name = "Apache 2.0", url = "http://swagger.io/terms/" },
                    termsOfService = "http://swagger.io/terms/"
                },
                host = url_,
                basePath = basePhats,
                tags = new List<Tag> { new Tag { name = "store", description = "Access to Petstore orders" }, new Tag { name = "sp2", description = "Access To Sp2" } },
                schemes = new List<string> { "https", "http" },
                paths = new Paths {
                    StoreOrder = new StoreOrder
                    {
                        post = new Post
                        {
                            tags = new List<string> { "store" },
                            summary = "Place an order for a pet",
                            description = "",
                            consumes = new List<string> { "application/json" },
                            produces = new List<string> { "application/json", "application/xml" },
                            parameters = new List<Parameter> {
                                new Parameter { @in = "body", name = "body", description = "order placed for purchasing the pet", required = true, schema = new Schema { Ref = "#/definitions/Order" } },
                            },
                            responses = new Responses { _200 = new _200 { schema = new Schema { Ref = "#/definitions/Order" }, description = "successful operation" }, _400 = new _400 { description = "Invalid Order" } },
                            operationId = "placeOrder"
                        }
                    },
                    StoreOrder2 = new StoreOrder2 {
                        post = new Post
                        {
                            tags = new List<string> { "sp2" },
                            summary = "post data to sp2",
                            description = "",
                            consumes = new List<string> { "application/json" },
                            produces = new List<string> { "application/json", "application/xml" },
                            parameters = new List<Parameter> {
                                new Parameter { @in = "body", name = "body", description = "order placed for purchasing the pet", required = true, schema = new Schema { Ref = "#/definitions/ParamDocSP2Post" } },
                            },
                            responses = new Responses { _200 = new _200 { schema = new Schema { Ref = "#/definitions/ParamDocSP2Post" }, description = "successful operation" }, _400 = new _400 { description = "Invalid Order" } },
                            operationId = "PostSp2"
                        }
                    }
                },
                securityDefinitions = new SecurityDefinitions
                {
                    api_key = new ApiKey { name = "api_key", type = "ApiKey", @in = "header" },
                    petstore_auth = new PetstoreAuth { type = "oauth2", authorizationUrl = "https://petstore.swagger.io/oauth/authorize", flow = "implicit", scopes = new Scopes { ReadPets = "read your pets", WritePets = "modify pets in your account" } }
                },
                definitions = new Definitions
                {
                    Order = new Order { properties = new Properties {
                        id = new Id { type = "integer", format = "int64" },
                        petId = new PetId { format = "integer", type = "int64" },
                        quantity = new Quantity { format = "integer", type = "int64" },
                        shipDate = new ShipDate { format = "date-time", type = "string" },
                        status = new Status { type = "string", description = "Order Status", @enum = new List<string> { "placed", "approved", "delivered" } },
                        complete = new Complete { type = "boolean" }
                    }, type = "object", xml = new Xml { name = "Order" } },
                    ParamDocSP2Post =new GeneralTable.ParamDocSP2Post
                    {
                             bl_date="Test1",
                              bl_no="test2",
                              jenis_sp2="ssss",
                    }
                 },
                 externalDocs=new ExternalDocs { description= "Find out more about Swagger", url= "http://swagger.io" }
            };

            return s;
        }

        // Mulai
        //public static SwaggerParams GetForDataSource(string url_, string basePhats)
        //{
        //    SwaggerParams s = new SwaggerParams
        //    {
        //        swagger = "2.0",
        //        info = new Info
        //        {
        //            description = "This is a sample server Petstore server.  You can find out more about Swagger at [http://swagger.io](http://swagger.io) or on [irc.freenode.net, #swagger](http://swagger.io/irc/).  For this sample, you can use the api key `special-key` to test the authorization filters.",
        //            version = "1.0.6",
        //            title = "Swagger I-HUB",
        //            contact = new Contact { email = "apiteam@swagger.io" },
        //            license = new License { name = "Apache 2.0", url = "http://swagger.io/terms/" },
        //            termsOfService = "http://swagger.io/terms/"
        //        },
        //        host = url_,
        //        basePath = basePhats,
        //        tags = new List<Tag> { new Tag { name = "store", description = "Access to Petstore orders" } },
        //        schemes = new List<string> { "https", "http" },
        //        paths = new Paths
        //        {
        //            StoreOrder = new StoreOrder
        //            {
        //                post = new Post
        //                {
        //                    tags = new List<string> { "store" },
        //                    summary = "Place an order for a pet",
        //                    description = "",
        //                    consumes = new List<string> { "application/json" },
        //                    produces = new List<string> { "application/json", "application/xml" },
        //                    parameters = new List<Parameter> { new Parameter { @in = "body", name = "body", description = "order placed for purchasing the pet", required = true, schema = new Schema { Ref = "#/definitions/Order" } } },
        //                    responses = new Responses { _200 = new _200 { schema = new Schema { Ref = "#/definitions/Order" }, description = "successful operation" }, _400 = new _400 { description = "Invalid Order" } },
        //                    operationId = "placeOrder"
        //                }
        //            }
        //        },
        //        securityDefinitions = new SecurityDefinitions
        //        {
        //            api_key = new ApiKey { name = "api_key", type = "ApiKey", @in = "header" },
        //            petstore_auth = new PetstoreAuth { type = "oauth2", authorizationUrl = "https://petstore.swagger.io/oauth/authorize", flow = "implicit", scopes = new Scopes { ReadPets = "read your pets", WritePets = "modify pets in your account" } }
        //        },
        //        definitions = new Definitions
        //        {
        //            Order = new Order
        //            {
        //                properties = new Properties
        //                {
        //                    id = new Id { type = "integer", format = "int64" },
        //                    petId = new PetId { format = "integer", type = "int64" },
        //                    quantity = new Quantity { format = "integer", type = "int64" },
        //                    shipDate = new ShipDate { format = "date-time", type = "string" },
        //                    status = new Status { type = "string", description = "Order Status", @enum = new List<string> { "placed", "approved", "delivered" } },
        //                    complete = new Complete { type = "boolean" }
        //                },
        //                type = "object",
        //                xml = new Xml { name = "Order" }
        //            }
        //        },
        //        externalDocs = new ExternalDocs { description = "Find out more about Swagger", url = "http://swagger.io" }
        //    };

        //    return s;
        //}
        // Selesai

        public class _200
        {
            public string description { get; set; }
            public Schema schema { get; set; }
        }

        public class _400
        {
            public string description { get; set; }
        }

        public class ApiKey
        {
            public string type { get; set; }
            public string name { get; set; }
            public string @in { get; set; }
        }

        public class Complete
        {
            public string type { get; set; }
        }

        public class Contact
        {
            public string email { get; set; }
        }

        public class Definitions
        {
            public Order Order { get; set; }
            public GeneralTable.ParamDocSP2Post ParamDocSP2Post { get;set;}// samakan nama judulnya
        }

        public class ExternalDocs
        {
            public string description { get; set; }
            public string url { get; set; }
        }

        public class Id
        {
            public string type { get; set; }
            public string format { get; set; }
        }

        public class Info
        {
            public string description { get; set; }
            public string version { get; set; }
            public string title { get; set; }
            public string termsOfService { get; set; }
            public Contact contact { get; set; }
            public License license { get; set; }
        }

        public class License
        {
            public string name { get; set; }
            public string url { get; set; }
        }

        public class Order
        {
            public string type { get; set; }
            public Properties properties { get; set; }
            public Xml xml { get; set; }
        }

        public class Parameter
        {
            public string @in { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public bool required { get; set; }
            public Schema schema { get; set; }
        }

        public class Paths
        {
            [JsonProperty("/docsp2/sp2")]
            public  StoreOrder StoreOrder { get; set; }

            [JsonProperty("/docsp2/sp3")]// tak boleh sama antar judul
            public StoreOrder2 StoreOrder2 { get; set; }

        }

        public class PetId
        {
            public string type { get; set; }
            public string format { get; set; }
        }

        public class PetstoreAuth
        {
            public string type { get; set; }
            public string authorizationUrl { get; set; }
            public string flow { get; set; }
            public Scopes scopes { get; set; }
        }

        public class Post
        {
            public List<string> tags { get; set; }
            public string summary { get; set; }
            public string description { get; set; }
            public string operationId { get; set; }
            public List<string> consumes { get; set; }
            public List<string> produces { get; set; }
            public List<Parameter> parameters { get; set; }
            public Responses responses { get; set; }
        }

        public class Properties
        {
            public Id id { get; set; }
            public PetId petId { get; set; }
            public Quantity quantity { get; set; }
            public ShipDate shipDate { get; set; }
            public Status status { get; set; }
            public Complete complete { get; set; }
        }

        public class Quantity
        {
            public string type { get; set; }
            public string format { get; set; }
        }

        public class Responses
        {
            public _200 _200 { get; set; }
            public _400 _400 { get; set; }
        }

        public class Schema
        {
            [JsonProperty("$ref")]
            public string Ref { get; set; }
        }

        public class Scopes
        {
            [JsonProperty("read:pets")]
            public string ReadPets { get; set; }

            [JsonProperty("write:pets")]
            public string WritePets { get; set; }
        }

        public class SecurityDefinitions
        {
            public ApiKey api_key { get; set; }
            public PetstoreAuth petstore_auth { get; set; }
        }

        public class ShipDate
        {
            public string type { get; set; }
            public string format { get; set; }
        }

        public class Status
        {
            public string type { get; set; }
            public string description { get; set; }
            public List<string> @enum { get; set; }
        }

        public class StoreOrder
        {
            public Post post { get; set; }
        }

        public class StoreOrder2
        {
            public Post post { get; set; }
        }

        public class Tag
        {
            public string name { get; set; }
            public string description { get; set; }
        }

        public class Xml
        {
            public string name { get; set; }
        }


    }


    // selesai

}
