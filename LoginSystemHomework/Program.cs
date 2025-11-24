using LoginSystemHomework.Db;
using LoginSystemHomework.Login;
using LoginSystemHomework.Registration;
using System.Net.Http.Headers;

namespace LoginSystemHomework
{
	internal class Program
	{
		private static void Main()
		{
			//var filePath = Path.Combine(Directory.GetCurrentDirectory(), "users.txt");
			//var db_file = new FileDatabase(filePath);
			//Console.WriteLine("User file path: " + filePath);

			Console.WriteLine("=== Welcome to simple login system. ===");

			string choice;

			while (true)
			{
				Console.Write("Do you have a registration? (y/n): ");
				choice = Console.ReadLine()?.Trim().ToLower();

				if (choice == "y" || choice == "n")
				{
					break;
				}
			}

			var db_file = new FileDatabase();

			var loginUser = new LoginUser(db_file);
			var registerUser = new RegistrationUser(db_file);

			if (choice == "n")
			{
				RegisterUser(registerUser);
			}

			LoginUser(loginUser, registerUser);
		}

		#region Login User

		private static void LoginUser(LoginUser loginUser, RegistrationUser registerUser)
		{
			Console.WriteLine("\n=== Login ===");
			Console.WriteLine("Message: Press 0 in the username input for registration.");

			#region oldschool-version-login

			//while (true)
			//{
			//	Console.Write("Username: ");
			//	string? loginUsername = Console.ReadLine();

			//	Console.Write("Password: ");
			//	string? loginPassword = Console.ReadLine();

			//	if (loginUser.ValidateLogin(loginUsername, loginPassword))
			//	{
			//		Console.WriteLine($"Login successful! Welcome to the system! :)");
			//		break;
			//	}
			//	else
			//	{
			//		Console.WriteLine("Invalid username or password!");
			//	}
			//}

			#endregion oldschool-version-login

			while (true)
			{
				string loginUsername = ReadValidatedInput(
					"Username: ",
					input =>
					{
						// just allow "0" temporarily
						return input == "0" || (!string.IsNullOrWhiteSpace(input) && loginUser.UsernameExists(input));
					},
					"Invalid username!"
				);

				// handle "0" immediately
				if (loginUsername == "0")
				{
					RegisterUser(registerUser); // go to registration
					continue; // restart the loop and ask for username again
				}

				string loginPassword = ReadValidatedInput(
					"Password: ",
					input => !string.IsNullOrWhiteSpace(input),
					"Invalid password!"
				);

				if (loginUser.ValidateLogin(loginUsername, loginPassword))
				{
					Console.WriteLine($"\nLogin successful! Welcome {loginUsername}!");
					break;
				}
				else
				{
					Console.WriteLine("Invalid username or password! Please try again.\n");
				}
			}
		}

		#endregion Login User

		#region Registration User

		private static void RegisterUser(RegistrationUser registerUser)
		{
			Console.WriteLine("\n=== Registration ===");

			#region oldschool-version

			//string username, password;

			//while (true)
			//{
			//	Console.Write("Create username (at least 3 symbols): ");
			//	username = Console.ReadLine();

			//	if (!string.IsNullOrEmpty(username) && username.Length >= 3 && !registerUser.UsernameExists(username))
			//	{
			//		break;
			//	}

			//	Console.WriteLine("Invalid username!");
			//}

			//while (true)
			//{
			//	Console.Write("Create password (at least 6 symbols):");
			//	password = Console.ReadLine();

			//	if (!string.IsNullOrWhiteSpace(password) && password.Length >= 6)
			//	{
			//		break;
			//	}

			//	Console.WriteLine("Password is invalid!");
			//}

			#endregion oldschool-version

			while (true)
			{
				string username = ReadValidatedInput(
					"Create username (at least 3 symbols): ",
					input => !string.IsNullOrEmpty(input) && input.Length >= 3 && !registerUser.UsernameExists(input),
					"Invalid username!"
				);

				string password = ReadValidatedInput(
					"Create password (at least 6 symbols): ",
					input => !string.IsNullOrWhiteSpace(input) && input.Length >= 6,
					"Invalid password!"
				);

				if (registerUser.Register(username, password))
				{
					Console.WriteLine("\nRegistration successful!\n");
					break;
				}
				else
				{
					Console.WriteLine("Username already exists! Please try again.\n");
				}
			}
		}

		private static string ReadValidatedInput(string prompt, Func<string, bool> validate, string errorMessage)
		{
			while (true)
			{
				Console.Write(prompt);
				string input = Console.ReadLine();

				if (validate(input))
				{
					return input;
				}

				Console.WriteLine(errorMessage);
			}
		}

		#endregion Registration User
	}
}