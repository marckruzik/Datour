namespace Datour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string log_folderpath = Loger.from_system_get_log_folderpath();
            Loger.from_log_folderpath_create_folder(log_folderpath);

            string log_filepath = Loger.from_system_get_log_filepath();

            string exceptioner_message = Exceptioner.from_args_get_message(args);
            if (exceptioner_message != String.Empty)
            {
                Loger.from_log_filepath_and_message_create_log(log_filepath, exceptioner_message);
                return;
            }

            string input = args[0];
            string filepath_with_prefix = IO.from_filepath_set_filepath_with_prefix(input);

            string runner_message = $"rename \"{input}\" into \"{filepath_with_prefix}\"";
            Loger.from_log_filepath_and_message_create_log(log_filepath, runner_message);

        }
    }
}