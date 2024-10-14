document.addEventListener("DOMContentLoaded", function () {
    const darkModeToggle = document.getElementById("darkModeToggle");
    const body = document.body;
    const currentTheme = localStorage.getItem("theme") || "light";

    // Apply the current theme
    if (currentTheme === "dark") {
        body.classList.add("dark-mode");
        document.documentElement.setAttribute("data-bs-theme", "dark");
    }

    darkModeToggle.addEventListener("click", function () {
        body.classList.toggle("dark-mode");
        const isDarkMode = body.classList.contains("dark-mode");

        // Save the theme to local storage
        localStorage.setItem("theme", isDarkMode ? "dark" : "light");

        // Change the data attribute for Bootstrap
        document.documentElement.setAttribute("data-bs-theme", isDarkMode ? "dark" : "light");
    });
});
