document.addEventListener("DOMContentLoaded", function () {
    const darkModeToggle = document.getElementById("darkModeToggle");
    const body = document.body;
    const currentTheme = localStorage.getItem("theme") || "light";

    if (currentTheme === "dark") {
        body.classList.add("dark-mode");
        document.documentElement.setAttribute("data-bs-theme", "dark");
    }

    darkModeToggle.addEventListener("click", function () {
        body.classList.toggle("dark-mode");
        const isDarkMode = body.classList.contains("dark-mode");

        localStorage.setItem("theme", isDarkMode ? "dark" : "light");

        document.documentElement.setAttribute("data-bs-theme", isDarkMode ? "dark" : "light");
    });
});
