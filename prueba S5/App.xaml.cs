namespace prueba_S5
{
    public partial class App : Application
    {
        public static PersonaRepository personaRepo {  get; set; }
        public App(PersonaRepository personaRepository)
        {
            InitializeComponent();

            MainPage = new Vistas.Principal();
            personaRepo=personaRepository;
        }
    }
}
