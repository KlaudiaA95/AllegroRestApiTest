using AllegroRestApiTests;
using NLog;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace AllegroTests
{
    public class BaseTest
    {
        protected Configuration configuration;
        protected CategoryRestClient _client;
        protected string _token;
        protected static readonly Logger log = LogManager.GetCurrentClassLogger();

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            log.Info("-- START GROUP OF TESTS --");
            configuration = new Configuration();
            _client = new CategoryRestClient(configuration);
            _token = OAuthTokenHelper.GetToken(configuration);
        }

        [SetUp]
        public void SetUp()
        {
            log.Info($" START TEST | {TestContext.CurrentContext.Test.Name} | {TestContext.CurrentContext.Test.ClassName}");
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                log.Info($"| ERROR | {TestContext.CurrentContext.Result.Message} ");
            }
            log.Info($"| END_TEST | STATUS | " +
                $"{TestContext.CurrentContext.Result.Outcome.Status} " +
                $"| {TestContext.CurrentContext.Test.Name} " +
                $"| {TestContext.CurrentContext.Test.ClassName} |");
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            log.Info("-- END GROUP OF TESTS --");
        }
    }
}