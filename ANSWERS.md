# Sprint 2 - Reponses

## Exercice 1 - Cartographie

En analysant le projet, on identifie trois grands groupes de classes qui evoluent ensemble. Le premier concerne la reservation : BookingService, RoomAssigner, Reservation, Room, RoomType, les interfaces IReservationRepository, IRoomRepository, IConfirmationSender, ICancellationPolicy et ses quatre implementations. Le deuxieme groupe concerne la facturation : BillingService, InvoiceGenerator, TaxCalculator, Invoice, InvoiceLine, IPricingStrategy et ses strategies Standard, Suite, Family ainsi que la PricingStrategyFactory. Le troisieme groupe concerne le menage : HousekeepingScheduler, CleaningTask, ICleaningPolicy avec StandardCleaningPolicy et VipCleaningPolicy, et ICleaningNotifier. Les adaptateurs infrastructure (InMemoryReservationStore, InMemoryRoomStore, EmailSender, SmsSender) forment un quatrieme ensemble technique sans logique metier.

## Exercice 2 - Decoupage

J'ai cree cinq projets distincts dans la solution. Hotel.Booking regroupe tout ce qui touche a la reservation (principe CCP : ces classes changent ensemble quand les regles metier evoluent). Hotel.Billing regroupe la facturation et le calcul de taxes, isole pour que changer un taux de TVA ne touche qu'un seul module. Hotel.Housekeeping regroupe le planning menage et les politiques de nettoyage. Hotel.Infrastructure contient les adaptateurs techniques (stores en memoire, email, SMS) sans aucune logique metier. Hotel.Runner est le seul point d'entree qui instancie et cable tout. Chaque module metier expose un dossier Contracts/ avec uniquement des types public (interfaces et DTOs), tout le reste est internal, ce qui rend les dependances accidentelles impossibles au niveau du compilateur.

## Exercice 3 - Test de la modification

Pour le scenario A (changer le linge tous les 2 jours au lieu de 3), seul Hotel.Housekeeping est touche, une ligne dans StandardCleaningPolicy. Pour le scenario B (TVA a 12%), seul Hotel.Billing est touche, une constante dans TaxCalculator. Dans les deux cas le principe CCP joue son role : les classes qui changent pour la meme raison sont au meme endroit. Pour le scenario C (ajout d'un canal push notification), aucun module metier n'est modifie : on cree une nouvelle classe PushNotificationSender dans Hotel.Infrastructure qui implemente l'interface ICleaningNotifier, et on l'injecte dans Hotel.Runner. C'est le principe Ports & Adapters qui protege le domaine : l'interface appartient au module metier, les implementations concretes appartiennent a l'infrastructure.
