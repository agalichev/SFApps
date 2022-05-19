// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;


namespace ModuleSevenApp // Note: actual namespace depends on the project name.
{
	public class Program
	{
		public static void Main(string[] args)
		{
			AppActions appActions = new AppActions();
			Shop.ShopName = "MajorTech";

			// Создаём страну

			Country Russia = new Country("Россия", "{0:######}", "{0:+7 (###) ###-##-##}");

			#region Cities creation // NEW version
			// Создаём города, магазины и точки выдачи товара

			Russia.Cities.Add(new City("Москва", new List<Shop>()));
            Russia[0].Shops.Add(new Shop(Russia, 0, "Таганская", "1", 109147));
            Russia[0].Shops.Add(new Shop(Russia, 0, "Бакунинская", "69к1", 105082));
            Russia[0].Shops.Add(new Shop(Russia, 0, "Ленинградский пр-т", "80к17", 109451));
            Russia[0].Shops.Add(new Shop(Russia, 0, "Братиславская", "20", 109451));

            Russia.Cities.Add(new City("Санкт-Петербург", new List<IssuePoint>()));
            Russia[1].IssuePoints.Add(new IssuePoint(Russia, 1, "Новоизмайловский пр-т", "101", 196247));
            Russia[1].IssuePoints.Add(new IssuePoint(Russia, 1, "Малый проспект В.О.", "31", 199178));
            Russia[1].IssuePoints.Add(new IssuePoint(Russia, 1, "Муринский 2-й проспект", "38", 194021));
            Russia[1].IssuePoints.Add(new IssuePoint(Russia, 1, "Коммуны", "59", 195030));

            Russia.Cities.Add(new City("Хабаровск", new List<IssuePoint>()));
            Russia[2].IssuePoints.Add(new IssuePoint(Russia, 2, "Краснореченская", "44", 680051));
            Russia[2].IssuePoints.Add(new IssuePoint(Russia, 2, "Ким Ю Чена", "44", 680021));

            Russia.Cities.Add(new City("Владивосток", new List<IssuePoint>()));
            Russia[3].IssuePoints.Add(new IssuePoint(Russia, 3, "Светланская", "108", 690001));
            Russia[3].IssuePoints.Add(new IssuePoint(Russia, 3, "Комсомольская", "1", 690078));
			#endregion
			
			// Создаём цены

			List<Margins> margins = new List<Margins>();
			margins.Add(new Margins(Russia["Москва"], 0.0));
			margins.Add(new Margins(Russia["Санкт-Петербург"], 500.0, 200.0));
			margins.Add(new Margins(Russia["Хабаровск"], 1700.0, 500.0));
			margins.Add(new Margins(Russia["Владивосток"], 1800.0, 600.0));

			// Создаём каталог товаров

			Catalogue catalogue = new Catalogue();
			catalogue.Products.Add(new Product(1, Product.Type.Видеокарта, "GIGABYTE Radeon RX 6700 XT GAMING OC 12G", Product.Origin.Китай, 89999));
			catalogue.Products.Add(new Product(2, Product.Type.Системный_блок, "игровой Lenovo Legion T5 26AMR5", Product.Origin.Китай, 149999));
			catalogue.Products.Add(new Product(3, Product.Type.Ноутбук, "игровой ASUS ROG Strix G15 Advantage Edition G513QY-HQ007T", Product.Origin.Китай, 169999));
			catalogue.Products.Add(new Product(4, Product.Type.Телевизор, "Samsung UE50TU7002U", Product.Origin.Китай, 51999));
			catalogue.Products.Add( new Product(5, Product.Type.Смартфон, "Apple iPhone 12 256GB (PRODUCT)RED (MGJJ3RU/A)", Product.Origin.Китай, 69999));
			catalogue.InitializePrices();

			// Формируем склад

			Stok stok = new Stok();
			stok.AddToStok(catalogue[0], 5);
			stok.AddToStok(catalogue[1], 3);
			stok.AddToStok(catalogue[2], 4);
			stok.AddToStok(catalogue[3], 2);
			stok.AddToStok(catalogue[4], 12);

			// Создаём корзину покупок

			Cart cart = new Cart();

			#region Execution

			// Цикл главной страницы

			const string AllowedChars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			Random rng = new Random();

			City YourCity = new City(); // Будет содержать выбранный город
			User buyer = new User(); // Будет содержать текущего пользователя или гостя
			List<User> users = new List<User>(); // Список зарегистрированных пользователей

			// Создаём лог заказов  < Не смог придумать лучше. Често, для меня крайне неудобны в обращении обобщенные типы, пока не хватает практики их применения,
			// а в рамках материалов курсов раскрыто только базовые вещи >

			OrdersLog ordersLog = new OrdersLog();

			int id = 0;
			int count = 0;

			const double pointDeliveryPrice = 100.0;

			do
            {
				Console.Clear();

				Console.WriteLine("\tГлавная страница\n");

				AppActions.SetTextColor($"\tМагазин {Shop.ShopName}\n", ConsoleColor.DarkYellow);

                Console.WriteLine($" {appActions.Begin} (F1) или {appActions.End} (F2)");
                var fkeyMain = Console.ReadKey();

                switch (fkeyMain.Key)
                {
                    case ConsoleKey.F1:

                        // Цикл выбора города (выбор города обязателен и с него всё начинается, так как далее будет происходить ценообрание в зависимости от города, в котором совершается покупка)
                       
						do
                        {
							Console.Clear();

							Console.WriteLine($" {appActions.SelectCity} (F1)\n {appActions.ToMain} (F2)");

                            var fkeyCity = Console.ReadKey();

                            switch (fkeyCity.Key)
                            {
                                case ConsoleKey.F1:

									YourCity = Russia.SelectCity();

									catalogue.SetCataloguePrices(YourCity, margins);

									// Цикл основного меню

									do
                                    {
										Console.Clear();

										Console.WriteLine($" {appActions.SignUp} (F1)\n {appActions.SignIn} (F2)\n {appActions.Profile} (F3)\n\n {appActions.ChangeCity} (F4)\n {appActions.SeeProducts} (F5)\n {appActions.ToCart} (F6)\n {appActions.OrdersHistory} (F7)\n\n {appActions.ToMain} (F8)");

										var fkeySignUp = Console.ReadKey();

										switch (fkeySignUp.Key)
                                        {
											case ConsoleKey.F1: // Зарегистрироваться

												Console.Clear();

												Console.WriteLine($"Регистрация пользователя");

												users.Add(User.RegisterUser(Russia, YourCity));

												continue;


											case ConsoleKey.F2: // Войти

												Console.Clear();

												Console.WriteLine($"Вход");

												buyer = User.SignIn(users);

												continue;


											case ConsoleKey.F3: // Открыть профиль пользователя

												if (buyer.Login != null)
												{
													Console.Clear();
													Console.WriteLine(User.DisplayUserData(buyer));
												}
												else
												{
													AppActions.SetTextColor(" Пользователь не вошёл", ConsoleColor.Red);
												}
												Console.ReadKey(true);

												continue;


											case ConsoleKey.F4: // Изменить город

												Console.Clear();

												YourCity = Russia.SelectCity();

												catalogue.SetCataloguePrices(YourCity, margins);

												continue;


											case ConsoleKey.F5: // Посмотреть товары

												// Цикл операций с каталогом, корзиной и складом

												do
												{
													Console.Clear();
													
													catalogue.DisplayCatalogue(stok);

													AppActions.SetTextColor($" товаров в корзине: {cart.DisplayCartCount()}\n", ConsoleColor.DarkGreen);

													Console.WriteLine($" {appActions.AddToCart} (F1)\n {appActions.Back} (F2)");

													var fkeyProducts = Console.ReadKey(true);

													switch (fkeyProducts.Key)
													{
														case ConsoleKey.F1: // Добавить товар в корзину по его ID

															Console.Write(" Введите ID товара: ");
															id = id.GetNumberInRange(catalogue[0].ID, catalogue.Products.Count);

															if (stok.GetStokProductCount(id) != 0)
															{
																Console.Write($" Введите количество приобретаемого товара, но не более {stok.GetStokProductCount(id)}: ");
																count = count.GetNumberInRange(0, stok.GetStokProductCount(id));
																cart.AddToCart(catalogue[id - 1], count);
															}

															stok.RemoveFromStok(id, count);

															continue;


														case ConsoleKey.F2: // Вернуться на предыдущую страницу
															break;


														default:
															continue;
													}

													break;

												}
												while (true);

												continue;


											case ConsoleKey.F6: // Открыть корзину

												do
												{
													Console.Clear();

													cart.DisplayCart();

													AppActions.SetTextColor($" товаров в корзине: {cart.DisplayCartCount()}\n", ConsoleColor.DarkGreen);

													Console.WriteLine($" {appActions.RemoveFromCart} (F1)\n {appActions.ClearCart} (F2)\n {appActions.Checkout} (F3)\n\n {appActions.Back} (F4)");

													var fkeyCart = Console.ReadKey(true);

													switch (fkeyCart.Key)
													{
														case ConsoleKey.F1: // Удалить товар из корзины

															Console.Write(" Введите ID товара: ");

															id = id.GetNumberInRange(catalogue[0].ID, catalogue.Products.Count);

															if (cart.GetPickedProductCount(id) != 0)
															{
																Console.Write($" Введите количество товара к удалению, но не более {cart.GetPickedProductCount(id)}: ");
																count = count.GetNumberInRange(0, cart.GetPickedProductCount(id));
																stok.AddToStok(catalogue[id - 1], count);
															}

															cart.RemoveFromCart(id, count);

															continue;


														case ConsoleKey.F2: // Очистить корзину

															cart.ClearCart(stok);

															break;


														case ConsoleKey.F3: // Оформить заказ

															Order<ShopDelivery, Shop> toshoporder = new Order<ShopDelivery, Shop>();
															Order<PickPointDelivery, IssuePoint> topointorder = new Order<PickPointDelivery, IssuePoint>();
															Order<HomeDelivery, Address> tohomeorder = new Order<HomeDelivery, Address>();

                                                            if (cart.pickedProducts.Count != 0)
                                                            {
                                                                Console.Clear();

                                                                AppActions.SetTextColor(" \n\t 1 -- Самовывоз\n\t 2 -- По адресу \n\t 3 -- В пункт выдачи\n", ConsoleColor.DarkYellow);

                                                                Console.Write(" Выберете способ доставки: ");

                                                                count = count.GetNumberInRange(1, 3);

                                                                switch (count)
                                                                {
                                                                    case 1:

																		if (YourCity.Shops != null)
                                                                        {
                                                                            YourCity.DisplayPoints(1);

                                                                            Console.Write($" Выберете точку доставки: ");

                                                                            id = id.GetNumberInRange(1, YourCity.Shops.Count);

																			var shopdelivery = new ShopDelivery(YourCity.Shops[id - 1]);

																			Console.WriteLine($"Цена доставки: {shopdelivery.Price + margins.Find(c => c.City.Name == YourCity.Name).DeliveryMargin}");

																			toshoporder = new Order<ShopDelivery, Shop>(cart.pickedProducts, RandomStrings(AllowedChars, 4, 4, rng), shopdelivery);
																		}
                                                                        else
                                                                        {
                                                                            AppActions.SetTextColor(" Способ доставки не доступен!", ConsoleColor.Red);
                                                                            Console.WriteLine(" Нажмите любую клавишу, чтобы продолжить");
                                                                            Console.ReadKey(true);
																			continue;
                                                                        }

                                                                        break;


                                                                    case 2:

                                                                        if (buyer.Login == null)
                                                                        {
																			buyer.Address = new Address();

																			buyer.Address.EnterAddress(Russia, YourCity);

                                                                        }

                                                                        var homedelivery = new HomeDelivery(buyer.Address, 100.0 + margins.Find(c => c.City.Name == YourCity.Name).DeliveryMargin);

																		//Console.WriteLine($"Цена доставки: {homedelivery.Price + margins.Find(c => c.City.Name == YourCity.Name).DeliveryMargin}");

																		Console.WriteLine($"Цена доставки: {homedelivery.Price}");

																		tohomeorder = new Order<HomeDelivery, Address>(cart.pickedProducts, RandomStrings(AllowedChars, 4, 4, rng), homedelivery);

																		break;


                                                                    case 3:

																		if (YourCity.IssuePoints != null)
																		{
																			YourCity.DisplayPoints(3);

																			Console.Write($" Выберете точку доставки: ");

																			id = id.GetNumberInRange(1, YourCity.IssuePoints.Count);

																			var pointdelivery = new PickPointDelivery(YourCity.IssuePoints[id - 1], 50.0 + margins.Find(c => c.City.Name == YourCity.Name).DeliveryMargin);

																			//Console.WriteLine($"Цена доставки: {pointdelivery.Price + margins.Find(c => c.City.Name == YourCity.Name).DeliveryMargin}");

																			Console.WriteLine($"Цена доставки: {pointdelivery.Price}");

																			topointorder = new Order<PickPointDelivery, IssuePoint>(cart.pickedProducts, RandomStrings(AllowedChars, 4, 4, rng), pointdelivery);
																		}
																		else
																		{
																			AppActions.SetTextColor(" Способ доставки не доступен!", ConsoleColor.Red);
																			Console.WriteLine(" Нажмите любую клавишу, чтобы продолжить");
																			Console.ReadKey(true);
																			continue;
																		}

																		break;
                                                                }

                                                                AppActions.SetTextColor($" {appActions.Checkout} <F1>\t {appActions.Cancel} <Любая клавиша>\n", ConsoleColor.DarkGreen);

                                                                var fkeyOrder = Console.ReadKey(true);

                                                                switch (fkeyOrder.Key)
                                                                {
                                                                    case ConsoleKey.F1: // Оформить заказ

																		//Order<ShopDelivery, Shop> ordertoshop = new Order<ShopDelivery, Shop>(cart.pickedProducts, RandomStrings(AllowedChars, 4, 4, rng), shopdelivery);
																		if (count == 1)
																		{
																			AppActions.SetTextColor($" Ваш заказ оформлен:\n{toshoporder.DisplayOrder()}", ConsoleColor.DarkYellow);

																			ordersLog.WriteToJournal(toshoporder.DisplayOrder()); // Сохраняем в лог заказов выполненный заказ
																		}
																		else if (count == 2)
																		{
																			AppActions.SetTextColor($" Ваш заказ оформлен:\n{tohomeorder.DisplayOrder()}", ConsoleColor.DarkYellow);

																			ordersLog.WriteToJournal(tohomeorder.DisplayOrder());
																		}
																		else if(count == 3)
                                                                        {
																			AppActions.SetTextColor($" Ваш заказ оформлен:\n{topointorder.DisplayOrder()}", ConsoleColor.DarkYellow);

																			ordersLog.WriteToJournal(topointorder.DisplayOrder());
																		}																	
																		
																		cart.ClearCart(); // Обязательно очищаем корзину, при этом не указаем в параметрах склад, иначе все туда вернётся

                                                                        break;


                                                                    //case ConsoleKey.F2: // Отмена

                                                                    //    break;


                                                                    default:

                                                                       // Console.WriteLine($" {appActions.Error}");

                                                                        continue;
                                                                }

                                                            }
                                                            else
                                                            {
                                                                AppActions.SetTextColor(" Оформление заказа невозможно, так как корзина пуста!", ConsoleColor.Red);
                                                                Console.WriteLine(" Нажмите любую клавишу, чтобы продолжить");
                                                                Console.ReadKey(true);
                                                            }
                                                            break;


														case ConsoleKey.F4: // Вернуться на предыдущую страницу
															break;


														default:
															continue;
													}

													break;

												}
												while(true);

												continue;


											case ConsoleKey.F7: // Открыть историю заказов

												Console.Clear();

												Console.WriteLine(" Ваши заказы:\n ");

												AppActions.SetTextColor(ordersLog.DisplayJournal(), ConsoleColor.Magenta);

												Console.WriteLine(" Нажмите любую клавишу, чтобы продолжить");
												Console.ReadKey(true);

												continue;


											case ConsoleKey.F8: // Вернуться на главную страницу

												break;


											default:

												Console.WriteLine($"{appActions.Error} {fkeyCity.Key}");

												continue;
										}

										break;

                                    }
                                    while (true);

                                    break;


                                case ConsoleKey.F2:

                                    break;


                                default:

                                    Console.WriteLine($"{appActions.Error} {fkeyCity.Key}");

                                    continue;
                            }

							break;

                        }
                        while (true);

                        continue;

                    case ConsoleKey.F2:

                        Console.WriteLine("Приложение завершило свою работу!");

                        break;

                    default:

                        Console.WriteLine($"{appActions.Error} {fkeyMain.Key}");

                        continue;
                }

				//Type t = YourCity._points.GetType();
				//if (t.Equals(typeof(Shop[])))
				//{
				//	Console.ForegroundColor = ConsoleColor.Yellow;
				//	Console.WriteLine("Доступные способы доставки:\n\t 1 -- Самовывоз\n\t 2 -- По адресу");
				//	Console.ResetColor();
				//}

				break;
            }
            while (true);

            Console.ReadKey();
            #endregion
        }

		private static string RandomStrings(string allowedChars, int minLength, int maxLength, Random rng)
		{
			char[] chars = new char[maxLength];
			int setLength = allowedChars.Length;

			int length = rng.Next(minLength, maxLength + 1);

			for (int i = 0; i < length; ++i)
			{
				chars[i] = allowedChars[rng.Next(setLength)];
			}

			return new string(chars, 0, length);
		}

	}

	abstract class Delivery<TAddress> where TAddress : Address
	{
		public abstract TAddress Address { get; set; }
		public abstract double Price { get; set; }
		public abstract string DeliveryName { get; }
	}

	class HomeDelivery : Delivery<Address>
	{
		private double _price;
		private Address _address;
		protected static string _delieryName = "Доставка по адресу";

		public override Address Address { get => _address; set => _address = value; }
		public override double Price { get => _price; set => _price = value; }
		public override string DeliveryName { get => _delieryName; }

		public HomeDelivery(Address Address, double price)
		{
			this.Address = Address;
			Price = price;
		}
	}

	class PickPointDelivery : Delivery<IssuePoint>
	{
		private double _price;
		private IssuePoint _address;
		protected static string _deliveryName = "Доставка до точки выдачи";

		public override IssuePoint Address { get => _address; set => _address = value; }
		public override double Price { get => _price; set => _price = value; }
		public override string DeliveryName { get => _deliveryName; }

		public PickPointDelivery(IssuePoint PAddress, double price)
		{
			Address = PAddress;
			Price = price;
		}
	}

	class ShopDelivery : Delivery<Shop>
	{
		private double _price = 0;
		private Shop _address;
		protected static string _deliveryName = "Самовывоз";

		public override Shop Address { get => _address; set => _address = value; }
		public override double Price { get => _price; set => _price = 0; }
		public override string DeliveryName { get => _deliveryName; }

		public ShopDelivery(Shop SAddress)
		{
			Address = SAddress;
		}

        public static explicit operator ShopDelivery(Delivery<Address> v)
        {
            throw new NotImplementedException();
        }
    }

	public class Country//<TCity> where TCity : City<Address>
	{
		private string _name;
		private List<City> _cities = new List<City>();
		private string? _pcodeSample;
		private string _mPhoneSample;
		//private TCity[] _cities;

		public string Name { get => _name; }
		public List<City> Cities { get => _cities; protected internal set => _cities = value; }
		protected internal string PCodeSample { get => _pcodeSample; }
		public string MPhoneSample { get => _mPhoneSample; }
		//public TCity[] Cities { get => _cities; }

		public Country(string name, string pcodeformat, string mphoneformat)
		{
			_name = name;
			_pcodeSample = pcodeformat;
			_mPhoneSample = mphoneformat;
		}

		public City SelectCity()
		{
			int key = 0;
			int x1, x2;
			int y1, y2;

			City yourCity;

			do
			{

				Console.WriteLine();

				for (int i = 0; i < _cities.Count; i++)
				{
					Console.ForegroundColor = ConsoleColor.Cyan;
					Console.WriteLine($"\t{i + 1} --\t{_cities[i].Name}");
				}

				Console.ResetColor();

				Console.WriteLine();

				Console.Write($" Выбор своего города (введите от 1 до {_cities.Count}), либо продолжите по умолчанию (0): ");

				key = key.GetNumberInRange(0, _cities.Count);

				if (key != 0)
				{
					yourCity = _cities[key - 1];
					key = 0;
				}
				else
				{
					yourCity = _cities[key];

				}

			}
			while (key != 0);

			Console.WriteLine();

			return yourCity;
		}

        //public TCity this[int index]
        public City this[int index]

        {
            get
            {
                if (index >= 0 && index < Cities.Count)
                {
                    return Cities[index];
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            protected internal set
            {
                if (index >= 0 && index < Cities.Count)
                {
                    Cities[index] = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        public City this [string name]
        {
            get
            {
				var city = Cities.Find(x => x.Name == name);
				if (city == null)
				{
					throw new Exception("Unknown name");
				}
                else
                {
					return city;
                }
			}
        }

    }

	public class City//<TAddress> where TAddress : Address
	{
		private string _name;
		//public TAddress[] _points;
		//private List<Address> _addresses;
		private List<Shop> _shops;
		private List<IssuePoint> _issuePoints;

		public string Name { get => _name; }
		//public List<Address> Addresses { get => _addresses; private set => _addresses = value; }
		public List<Shop> Shops { get => _shops; private set => _shops = value; }
		public List<IssuePoint> IssuePoints { get => _issuePoints; private set => _issuePoints = value; }

		public City() { }

		//public City(string Name, TAddress[] points)
		//      {
		//	this._points = points;
		//	_name = Name;
		//      }

		//public City(string Name, List<Address> addresses)
		//{
		//	_name = Name;
		//	Addresses = addresses;
		//}

		public City(string Name, List<Shop> shops)
		{
			_name = Name;
			Shops = shops;
		}

		public City(string Name, List<IssuePoint> issuePoints)
		{
			_name = Name;
			IssuePoints = issuePoints;
		}

		public Shop this[ushort index]
		{
			get
			{
				if (index >= 0 && index < _shops.Count)
				{
					return _shops[index];
				}
				else
				{
					throw new ArgumentOutOfRangeException();
				}
			}
			set
			{
				if (index >= 0 && index < _shops.Count)
				{
					_shops[index] = value;
				}
				else
				{
					throw new ArgumentOutOfRangeException();
				}
			}
		}

		public IssuePoint this[short index]
		{
			get
			{
				if (index >= 0 && index < _issuePoints.Count)
				{
					return _issuePoints[index];
				}
				else
				{
					throw new ArgumentOutOfRangeException();
				}
			}
			set
			{
				if (index >= 0 && index < _issuePoints.Count)
				{
					_issuePoints[index] = value;
				}
				else
				{
					throw new ArgumentOutOfRangeException();
				}
			}
		}

		public void DisplayPoints(int count)
		{
			if (count == 1)
			{
				if (Shops != null)
				{
					Console.WriteLine(" Магазины:");
					//foreach (Shop shop in Shops)
					//{
					//	Console.WriteLine($"\t> {shop.DisplayAddress()}");
					//}
					for (int i = 0; i < Shops.Count; i++)
					{
						AppActions.SetTextColor($"\t{i + 1} --\t{Shops[i].DisplayAddress()}", ConsoleColor.Cyan);
					}
				}
			}
			else
			{
				if (IssuePoints != null)
				{
					Console.WriteLine(" Пункты выдачи:");
					//foreach (IssuePoint issuepoint in IssuePoints)
					//{
					//	Console.WriteLine($"\t> {issuepoint.DisplayAddress()}");
					//}
					for (int i = 0; i < IssuePoints.Count; i++)
					{
						AppActions.SetTextColor($"\t{i + 1} --\t{IssuePoints[i].DisplayAddress()}", ConsoleColor.Cyan);
					}
				}
			}

			Console.WriteLine();
		}
	}

	public class Address
	{
		private string _city;
		private string _street;
		private string _building;
		private int _appartment;
		private int _postcode;
		private string _country;
		//private string _postcode;

		public string? PCodeSample { get; set; }
		public string? Description { get; set; }
		public string Country { get => _country; set => _country = value; }
		public string City { get => _city; set => _city = value; }
		public string Street { get => _street; set => _street = value; }
		public string Building { get => _building; set => _building = value; }
		public int Appartment { get => _appartment; set => _appartment = value; }
		public int Postcode { get => _postcode; set => _postcode = value; }

		public Address() { }

		public Address(string country, string city, string street, string building, int appartment, int postcode/*, string format = "{0:######}", string description = ""*/)

		//public Address(string country, string city, string street, string building, int appartment, int postcode)
		{
			Description = "Адрес: ";
			Country = country;
			City = city;
			Street = street;
			Building = building;
			Appartment = appartment;
			Postcode = postcode/*.FormatPostcode(format)*/;
			//Description = String.Format("{0}: ", description);
		}

		//----------- тестовый вариант
		//     public Address(Country country, int cityindex, string street, string building, int appartment, int postcode)
		//     {
		//         Country = country.Name;
		////PCFormat = country.PCodeFormat;
		//         City = country.Cities[cityindex].Name;
		//         Street = street;
		//         Building = building;
		//Appartment = appartment;
		//         Postcode = postcode/*.SetPostcodeFormat(country?.PostcodeFormat)*/;
		//     }

		public Address(Country country, City city, string street, string building, int appartment, int postcode)
		{

			Country = country.Name;
			PCodeSample = country.PCodeSample;
			City = city.Name;
			Street = street;
			Building = building;
			Appartment = appartment;
			Postcode = postcode/*.SetPostcodeFormat(country?.PostcodeFormat)*/;
		}

		public virtual void EnterAddress(Country country = null, City city = null/*string country = "Default", string city = "Default", string format = "{0:######}"*/)
		{

			Description = "Адрес: ";

			Console.WriteLine(" Укажите адрес");

			if (country == null)
			{
				Console.Write("\tСтрана: ");
				Country = Country.CheckName();
			}
			else
			{
				Country = country.Name;
				PCodeSample = country.PCodeSample;
			}

			if (city == null)
			{
				Console.Write("\tГород: ");
				City = City.CheckName();
			}
			else
			{
				City = city.Name;
			}

			Console.Write("\tУлица: ");

			Street = Street.CheckName();

			do
			{
				Console.Write("\tДом / Строение (могут быть буквы): ");
				
				Building = Console.ReadLine();

				if (Regex.IsMatch(Building, "^(([1-9]{1})([a-zA-Zа-яА-Я])*)"))
				{
					break;
				}
				else
				{
					Console.WriteLine(" Неверный номер дома!");
				}
			}
			while (true);

			Console.Write("\tКвартира: ");

			Appartment = Appartment.GetNumberInRange(0, 1000);

			Console.Write("\tПочтовый индекс: ");

			if (country != null)
			{
				Postcode = GetPostcode(country.PCodeSample);
			}
			else
			{
				Postcode = Console.ReadLine().CheckNumber();
			}
		}

		public int GetPostcode(string format = "{0:######}")
		{
			int count = 0;
			int temp = 0;

			foreach (char c in format)
			{
				if (c == '#')
				{
					count++;
				}
			}

			return temp.GetNumberInRange(0, (int)Math.Pow(10, count) - 1);
		}

		public virtual string DisplayAddress()
		{
			string format;
			format = PCodeSample ?? "{0:#}";
			string address = $"{Description}{Country}, г. {City}, улица {Street}, д.{Building}, кв.{Appartment}, {String.Format(format, Postcode)}";

			return address;
		}
	}

	public class Shop : Address
	{
		protected static string _shopName;

		public static string ShopName { get => _shopName; protected internal set => _shopName = value; }
		public static string Title { get; } = "Сеть магазинов цифровой техники";

		public Shop(string shopname)
		{
			_shopName = shopname;
		}

		public Shop(string country, string city, string street, string building, int postcode) : base(country, city, street, building, 0, postcode)
		{
			Description = String.Format("{0} {1}: ", _shopName, Title);
		}

		public Shop(Country country, int cityindex, string street, string building, int postcode) : base(country, new City (), street, building, 0, postcode)
		{
			
			Description = String.Format("{0} {1}: ", _shopName, Title);
			City = country.Cities[cityindex].Name;
		}

		public override void EnterAddress(Country country = null, City city = null)
		{
			Console.Write("Описание: ");
			Description = String.Format("{0} {1}: ", _shopName, Console.ReadLine());

			if (country == null)
			{
				Console.Write("Страна: ");
				Country = Country.CheckName();
			}
			else
			{
				Country = country.Name;
			}

			if (city == null)
			{
				Console.Write("Город: ");
				City = City.CheckName();
			}
			else
			{
				City = city.Name;
			}

			Console.Write("Улица: ");
			Street = Street.CheckName();

			do
			{
				Console.Write("Дом / Строение (могут быть буквы): ");
				//Building = Building.CheckName();
				Building = Console.ReadLine();
				if (Regex.IsMatch(Building, "^(([1-9]{1})([a-zA-Zа-яА-Я])*)"))
					break;
				else
					Console.WriteLine("Неверный номер дома!");
			}
			while (true);

			Console.Write("Почтовый индекс: ");

			if (country != null)
				Postcode = GetPostcode(country.PCodeSample);
			else
				Postcode = Console.ReadLine().CheckNumber();
		}

		public override string DisplayAddress()
		{
			string format;
			format = PCodeSample ?? "{0:#}";

			return $"{Description}{Country}, г. {City}, улица {Street}, д.{Building}, {String.Format(format, Postcode)}";
		}

	}

	public class IssuePoint : Shop
	{
		public static string Title { get; } = "Пункт выдачи";

		public IssuePoint(Country country, int cityindex, string street, string building, int postcode) : base(country, cityindex, street, building, postcode)
		{
			Description = String.Format("{0} {1}: ", _shopName, Title);
		}
	}

	class Margins
	{
		private double _deliveryMargin;
		private double _productMargin;
		private City _city;

		public double DeliveryMargin { get { return _deliveryMargin; } set { _deliveryMargin = value; } } // Наценка на доставку в определенный город (до точки выдачи)
		public double ProductMargin { get { return _productMargin; } set { _productMargin = value; } } // Наценка на товар
		public City City { get { return _city; } set { _city = value; } }

		public Margins(City City, double productmargin, double deliverymargin = 0)
		{
			DeliveryMargin = deliverymargin;
			ProductMargin = productmargin;
			this.City = City;
		}
	}

	#region Enxtension methods
	public static class IntExtansions
	{
		public static int GetNumberInRange(this int number, int a, int b)
		{
			string? inputstr;
			bool check;

			do
			{
				inputstr = Console.ReadLine();
				check = !int.TryParse(inputstr, out number) || (inputstr == "");

				if (check || ((number < a) || (number > b)))
				{
					Console.Write($"Недопустимый ввод {number}. Попробуйте снова ввести от {a} до {b}: ");
				}

			}
			while (check || (number < a) || (number > b));

			return number;

		}

		//      public static string FormatPostcode(this int inputstr, string format)
		//{
		//	return String.Format(format, inputstr);
		//}
	}

	public static class LongExtansions
	{
		public static long GetPhoneNumber(this long number, string format)
		{
			string? inputstr;
			bool check;
			int count = 0;

			foreach (char c in format)
			{
				if (c == '#')
					count++;
			}

			do
			{
				inputstr = Console.ReadLine();
				check = !long.TryParse(inputstr, out number) | (inputstr == "");

				if (!check && ((number < Math.Pow(10, count - 1))) | (number > Math.Pow(10, count) - 1))
				{
					Console.Write($"Недопустимый номер телефона {number}. Должно быть {count} цифр без кода. Попробуйте снова: ");
				}

			}
			while (check | ((number < Math.Pow(10, count - 1))) | (number > Math.Pow(10, count) - 1));

			return number;
		}
	}

	public static class StringExtensions
	{
		public static string CheckName(this string inputstr)
		{

			bool check;
			string _errorDescription = $"Неопустимый ввод {inputstr}. Попробуйте ввести снова: ";

			do
			{
				inputstr = Console.ReadLine();
				check = string.IsNullOrEmpty(inputstr) || Regex.IsMatch(inputstr, "[0-9]+");

				if (check)
				{
					Console.Write(_errorDescription, inputstr);
				}
			}
			while (check);

			return String.Format("{0}{1}", char.ToUpper(inputstr[0]), inputstr.Remove(0, 1));
		}
		public static string SetPassword(this string inputstr)
		{
			bool inputcheck;
			bool confirmcheck;
			string password = "";
			string confirm = "";
			string actF1 = "Повторите пароль";
			string actF2 = "задайте пароль заново";
			string errorDescription = "Пароли не совпадают!";
			int x;// = Console.CursorLeft;
			int y;// = Console.CursorTop;

			do
			{
				Console.Write("Задайте пароль: ");

				password = password.EnterHidedSymbols();

				Console.Write("Повторите пароль: ");

				confirm = confirm.EnterHidedSymbols();
				inputcheck = confirm.CheckPassword(password, actF1, actF2, errorDescription);

				if (!inputcheck)
				{
					password = "";
					confirm = "";
				}
			}
			while (!inputcheck);

			Console.WriteLine();

			return password;
		}
		public static string EnterHidedSymbols(this string inputstr)
		{
			int x;// = Console.CursorLeft;
			int y;// = Console.CursorTop;

			while (true)
			{
				(x, y) = Console.GetCursorPosition();
				var key = Console.ReadKey(true); //не отображаем клавишу

				if (key.Key == ConsoleKey.Enter)
				{
					Console.WriteLine();
					break;
				}
				else if (key.Key != ConsoleKey.Backspace)
				{
					Console.Write("*"); //рисуем звезду вместо символа
					inputstr += key.KeyChar; //копим в пароль символы	
				}
				else if (key.Key == ConsoleKey.Backspace & inputstr.Length != 0)
				{
					if (inputstr.Length > 1)
					{
						inputstr = inputstr.Remove(inputstr.Length - 2, 1);
					}
					else
					{
						inputstr = inputstr.Remove(inputstr.Length - 1, 1);
					}

					Console.SetCursorPosition(x - 1, y);
					Console.Write(" ");
					Console.SetCursorPosition(x - 1, y);
				}
			}

			return inputstr;
		}
		public static bool CheckPassword(this string inputstr, string password, string actF1, string actF2, string errordescription)
		{
			bool check;
			bool confirm;

			if (inputstr != password)
			{
				AppActions.SetTextColor($"\n{errordescription}!", ConsoleColor.Red);

				do
				{
					Console.Write($"\n{actF1} (F1) или {actF2} (F2)");
					Console.WriteLine();

					var fkey = Console.ReadKey(true);
					inputstr = "";

					switch (fkey.Key)
					{
						case ConsoleKey.F1:

							Console.Write($"{actF1}: ");

							inputstr = inputstr.EnterHidedSymbols();

							if (inputstr != password)
							{
								Console.ForegroundColor = ConsoleColor.Red;
								Console.WriteLine($"\n{errordescription}");
								Console.ResetColor();

								check = false;
								confirm = false;

								break;
							}
							else
							{
								check = true;
								confirm = true;

								break;
							}

							break;


						case ConsoleKey.F2:

							check = true;
							confirm = false;

							break;


						default:

							password = "";
							check = false;
							confirm = false;

							continue;
					}

				}
				while (!check);

				password = "";
			}
			else
			{
				confirm = true;
			}

			return confirm;
		}
		public static int CheckNumber(this string inputstr)
		{
			string _errorDescription = $"Недопустимый ввод {inputstr}";
			//bool check; 
			int number;

			//do
			//{
			//	inputstr = Console.ReadLine();
			//	check = !int.TryParse(inputstr, out number) || (inputstr == "");

			//	if (check)
			//	{
			//		Console.Write(_errorDescription);
			//	}

			//}
			//while (check);

			while (true)
			{
				if (!int.TryParse(inputstr, out number) || (inputstr == ""))
				{
					Console.WriteLine(_errorDescription);
					Console.Write("Попробуйте ещё: ");
					Console.ReadLine();
				}
				else
					break;
			}

			return number;
		}
	}
	#endregion

	class User
	{
		private string? _firstname;
		private string? _lastname;
		private string? _patronymic;
		private string? _login;
		private string? _password;
		private Address? _address;
		private long _phone;

		public string? MPhoneSample { get; set; }
		public string? Firstname { get => _firstname; protected set => _firstname = value; }
		public string? Lastname { get => _lastname; protected set => _lastname = value; }
		public string? Patronymic { get => _patronymic; protected set => _patronymic = value; }
		public string? Login { get => _login; protected set => _login = value; }
		protected private string? Password { get => _password; set => _password = value; }
		public Address? Address { get => _address; set => _address = value; }
		protected long Phone { get { return _phone; } }

		public User() { }

		public static User RegisterUser(Country country, City city/*string country = "Default", string city = "Default", string pcodeformat = "{0:######}", string mphoneformat = "{0:+7 (###) ###-##-##}"*/)
		{
			User user = new User();

			Console.Write("Введите Имя: ");
			user.Firstname = user.Firstname.CheckName();

			Console.Write("Введите Фамилию: ");
			user.Lastname = user.Lastname.CheckName();

			Console.Write("Введите Отчество: ");
			user.Patronymic = user.Patronymic.CheckName();

			Console.Write("Введите Логин: ");
			user.Login = user.Login.CheckName();

			user.Password = user.Password.SetPassword();

			user.Address = new Address();
			user.Address.EnterAddress(country, city/*, pcodeformat*/);

			user.Address.Description = "Адрес: ";

			user.MPhoneSample = country.MPhoneSample;

			Console.Write("Введите моб. телефон: ");

			user._phone = user.Phone.GetPhoneNumber(user.MPhoneSample);

			return user;
		}

		public static User SignIn(List<User> users)
		{
			string login;
			string password = "";
			string actF1 = "Введите пароль";
			string actF2 = "смените пользователя";
			string errorDescription = "Неверно введён пароль!";
			bool check;
			bool confirm;
			int left;
			int top;

			User user = new User();

			do
			{
				Console.Write("Введите логин: ");
				login = Console.ReadLine();

				user = users.Find(x => x._login == login);

				if (user == null)
				{
					AppActions.SetTextColor("Пользователь не найден!", ConsoleColor.Red);

					Console.Write($"\nПопробовать снова (F1) или отменить вход (F2)");
					Console.WriteLine();

					var fkey = Console.ReadKey();

                    switch (fkey.Key)
                    {
						case ConsoleKey.F1:

							confirm = false;

							continue;


						case ConsoleKey.F2:

							confirm = true;

							break;

						default:

							confirm = false;

							continue;

					}
				}
				else
				{
					Console.Write("Введите пароль: ");

					password = password.EnterHidedSymbols();
					confirm = password.CheckPassword(user.Password, actF1, actF2, errorDescription);

                    if (confirm)
                    {
						Console.WriteLine($"Вход выполнен {user.Login}");
						Console.WriteLine(" Нажмите любую клавишу, чтобы продолжить");
						Console.ReadKey(true);
					}
				}
			}
			while (!confirm);

			return user;
		}

		public static string DisplayUserData(User user)
		{
			return $" {user.Firstname}\n {user.Lastname[0]}.\n {user.Login}.\n Моб. телефон: {String.Format(user.MPhoneSample, user.Phone)}";
		}
	}

	public class AppActions
	{
		public readonly string Begin = "<Приступить к покупкам>";
		public readonly string End = "<Завершить работу приложения>";
		public readonly string SignUp = "<Зарегистрироваться>";
		public readonly string Profile = "<Открыть профиль>";
		public readonly string SignIn = "<Войти>";
		public readonly string LogOff = "<Выйти>";
		public readonly string SelectCity = "<Выбрать город>";
		public readonly string ChangeCity = "<Изменить город>";
		public readonly string Skip = "<Пропустить>";
		public readonly string ToMain = "<Вернуться на главную страницу>";
		public readonly string Back = "<Назад>";
		public readonly string SeeProducts = "<Открыть каталог товаров>";
		public readonly string AddToCart = "<Добавить в корзину>";
		public readonly string ToCart = "<Перейти к корзине>";
		public readonly string RemoveFromCart = "<Удалить товар из корзины>";
		public readonly string ClearCart = "<Очистить корзину>";
		public readonly string Checkout = "<Оформить заказ>";
		public readonly string OrdersHistory = "<Открыть историю заказов>";
		public readonly string Error = "<Недопустимая команда>";
		public readonly string Cancel = "<Отменить>";

		public AppActions()
		{

		}

		public static void SetTextColor(string text, ConsoleColor color)
		{
			Console.ForegroundColor = color;
			Console.WriteLine(text);
			Console.ResetColor();
		}
	}

	class Product
    {
		private int _id;
		private double _price;
		
		public int ID { get => _id; set => _id = value; }
		public double Price { get => _price; set => _price = value; }
		public string Description { get; set; }

		public Type PType;
		public Origin POrigin;

		public enum Origin : byte
        {
			Китай = 0,
			Тайвань,
			США
        }

		public enum Type : byte
        {
			Видеокарта = 0,
			Системный_блок,
			Смартфон,
			Телевизор,
			Ноутбук
        }

		public Product() 
		{

		}

		public Product(int id, Type ptype,string description, Origin porigin, double price)
        {
			ID = id;
			PType = ptype;
			Description = description;
			POrigin = porigin;
			Price = price;
        }

		public string DisplayProduct()
        {
			return $" ID-{ID} {PType} {Description} {POrigin} {Price}";
        }
    }

	class Cart
    {
		private double _totalSum;

		public double TotalSum { get => _totalSum; set => _totalSum = value; }
		public List<Product> pickedProducts;
		
		public Cart()
        {
			pickedProducts = new List<Product>();
        }

		public void RemoveFromCart(int productid, int count = 0)
        {
			if (pickedProducts == null)
			{
				AppActions.SetTextColor(" Корзина пуста!", ConsoleColor.Red);
				Console.WriteLine(" Нажмите любую клавишу, чтобы продолжить");
				Console.ReadKey(true);

			}
			if (pickedProducts.Find(p => p.ID == productid) == null)
			{
				AppActions.SetTextColor($" Нет такого товара в корзине!", ConsoleColor.Red);
				Console.WriteLine(" Нажмите любую клавишу, чтобы продолжить");
				Console.ReadKey(true);
			}
			else
			{
				for (int i = 0; i < count; i++)
				{
					pickedProducts.Remove(pickedProducts.Find(p => p.ID == productid));
				}
			}
		}
		
		public void AddToCart(Product product, int count = 0)
        {
			for (int i = 0; i < count; i++)
			{
				pickedProducts.Add(product);
			}
        }

		public void ClearCart(Stok stok = null)
        {
			if (stok != null)
			{
				foreach (Product product in pickedProducts)
				{
					stok.AddToStok(product, 1);
				}
			}
			pickedProducts.Clear();
			TotalSum = 0;

			AppActions.SetTextColor(" Корзина очищена!", ConsoleColor.DarkYellow);
			Console.WriteLine(" Нажмите любую клавишу, чтобы продолжить");
			Console.ReadKey();
		}

		public int DisplayCartCount()
        {
			int count = pickedProducts.Count;
			return count;
        }

		public void DisplayCart()
        {
			if (pickedProducts != null)
			{
				TotalSum = 0;
				foreach (Product product in pickedProducts)
				{
					AppActions.SetTextColor($" -- {product.DisplayProduct()}", ConsoleColor.Cyan);
					TotalSum += product.Price;
				}
			}
            else
            {
				AppActions.SetTextColor("Корзина пуста!", ConsoleColor.Red);
            }

			AppActions.SetTextColor($"\n Общая сумма = {TotalSum}", ConsoleColor.DarkYellow);

			Console.WriteLine();
		}

		public int GetPickedProductCount(int productid)
		{
			int count = 0;

			foreach (Product product in pickedProducts)
			{
				if (product.ID == productid)
				{
					count++;
				}
			}

			return count;
		}

	}

	class Stok
    {
		public List<Product> stok;

		public Stok()
        {
			stok = new List<Product>();
		}

		public void RemoveFromStok(int productid, int count = 0)
        {
			if(stok == null)
            {
				AppActions.SetTextColor("Нет товаров на складе!", ConsoleColor.Red);
				Console.WriteLine("Нажмите любую клавишу, чтобы продолжить");
				Console.ReadKey(true);
			}
			if (stok.Find(p => p.ID == productid) == null)
            {
				AppActions.SetTextColor($"Нет товара {productid} на складе!", ConsoleColor.Red);
				Console.WriteLine("Нажмите любую клавишу, чтобы продолжить");
				Console.ReadKey(true);
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    stok.Remove(stok.Find(p => p.ID == productid));
                }
            }
        }

		public void AddToStok(Product product, int count = 0)
        {
			for (int i = 0; i < count; i++)
			{
				stok.Add(product);
			}
        }

		public int GetStokProductCount(int productid)
        {
			int count = 0;
			
			foreach (Product product in stok)
            {
				if(product.ID == productid)
                {
					count++;
                }
            }

			return count;
        }

		public void DisplayStok()
        {
			foreach (Product product in stok)
            {
				Console.WriteLine(product.DisplayProduct());
            }
        }

		public Product this[int index]
        {
			//get => stok[index];
			//set => stok[index] = value;

			get
			{
				if (index >= 0 && index < stok.Count)
				{
					return stok[index];
				}
				else
				{
					throw new ArgumentOutOfRangeException();
				}
			}
			set
			{
				if (index >= 0 && index < stok.Count)
				{
					stok[index] = value;
				}
				else
				{
					throw new ArgumentOutOfRangeException();
				}
			}
		}

    }

	class Catalogue
    {
		private double[] _origPrices;
		private List<Product> _products;

		public double[] OrigPrices { get => _origPrices; set => _origPrices = value; }
		public List<Product> Products { get => _products; set => _products = value; }

		public Catalogue()
        {
			Products = new List<Product>();
		}

		public void DisplayCatalogue(Stok stok)
        {

			foreach (Product product in Products)
            {
				if (stok.stok.Find(p => p.ID == product.ID) == null)
				{
					AppActions.SetTextColor($" -- {product.DisplayProduct()} нет в наличии", ConsoleColor.Red);
				}
				else
				{

					AppActions.SetTextColor($" -- {product.DisplayProduct()} <на складе {stok.GetStokProductCount(product.ID)}>", ConsoleColor.Cyan);
				}
			}

			Console.WriteLine();
        }

		public void InitializePrices()
        {
			if (OrigPrices == null)
			{
				OrigPrices = new double[Products.Count];
				foreach (Product product in Products)
				{
					OrigPrices[product.ID - 1] = product.Price;
				}
			}
            else
            {
				foreach (Product product in Products)
                {
					product.Price = OrigPrices[product.ID - 1];
                }
            }
        }

		public void SetCataloguePrices (City yourcity, List<Margins> margins)
        {
			InitializePrices();

			var localprices = margins.Find(p => p.City.Name == yourcity.Name);
			
			foreach (Product product in Products)
            {
				product.Price += localprices.ProductMargin;
            }

        }

		public Product this[int index]
		{
			get
			{
				if (index >= 0 && index < Products.Count)
				{
					return Products[index];
				}
				else
				{
					throw new ArgumentOutOfRangeException();
				}
			}
			set
			{
				if (index >= 0 && index < Products.Count)
				{
					Products[index] = value;
				}
				else
				{
					throw new ArgumentOutOfRangeException();
				}
			}
		}
	}

	class Order<TDelivery, TPoint> where TDelivery : Delivery<TPoint> where TPoint : Address
	{
		private string _number;
		private string _description;
		private double _totalSum;
		private string _productData;
		private List<Product> _cart;
		public TDelivery Delivery;

		public string Number { get => _number; set => _number = value; }
		public string Description { get => _description; protected set => _description = value; }
		public double TotalSum { get => _totalSum; protected set => _totalSum = value; }
		public string ProductData { get => _productData; protected set => _productData = value; }
		public List<Product> Cart { get => _cart; }


		public Order()
        {

        }

		public Order(List<Product> pickedproduts, string number, TDelivery delivery)
        {
			_cart = pickedproduts;
			Number = number;
			Delivery = delivery;
			TotalSum = 0;
			ProductData = "";

			foreach (Product product in Cart)
            {
				TotalSum += product.Price;
				ProductData += $"{product.DisplayProduct()}\n\t";

			}
        }

        public string DisplayOrder()
        {
            return $" Номер заказа: {Number}\n Способ доставки: {Delivery.DeliveryName}\n Точка доставки: {Delivery.Address.DisplayAddress()}\n Цена доставки: {Delivery.Price}\n Товар: {ProductData}\n Общая сумма заказа: {TotalSum}\n";
        }

        // ... Другие поля
    }

	class OrdersLog
	{
		private string _log;

		public string Log { get => _log; protected set => _log = value; }

		public OrdersLog()
		{
			Log = "";
		}

		public void WriteToJournal(string orderdata)
		{
			Log += $"{orderdata}\n\n";
		}

		public string DisplayJournal()
		{
			return Log;
		}
    }

}
