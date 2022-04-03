using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using CreateAQuiz.Business.Abstract;
using CreateAQuiz.Business.Concrete;
using CreateAQuiz.Core.Utilities.Interceptors;
using CreateAQuiz.Core.Utilities.Security.Jwt;
using CreateAQuiz.DataAccess.Abstract;
using CreateAQuiz.DataAccess.Concrete;

namespace CreateAQuiz.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ArticleManager>().As<IArticleService>().SingleInstance();
            builder.RegisterType<EfArticleDal>().As<IArticleDal>().SingleInstance();

            builder.RegisterType<QuestionManager>().As<IQuestionService>().SingleInstance();
            builder.RegisterType<EfQuestionDal>().As<IQuestionDal>().SingleInstance();

            builder.RegisterType<QuizManager>().As<IQuizService>().SingleInstance();
            builder.RegisterType<EfQuizDal>().As<IQuizDal>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();

            builder.RegisterType<TokenGenerator>().As<ITokenGenerator>();
            builder.RegisterType<AuthManager>().As<IAuthService>();



            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }


    }
}
