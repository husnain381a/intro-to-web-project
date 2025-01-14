// JavaScript for Theme Toggle
const darkModeIcon = document.querySelector('#darkMode-icon');
const rootElement = document.documentElement;

// Ensure Light Mode is Default
rootElement.classList.add('light-mode'); // Light mode active by default
darkModeIcon.classList.add('bx-sun'); // Icon for light mode

// Theme Toggle Handler
darkModeIcon.onclick = () => {
  if (rootElement.classList.contains('light-mode')) {
    rootElement.classList.remove('light-mode'); // Switch to Dark Mode
    rootElement.classList.add('dark-mode');
    darkModeIcon.classList.replace('bx-sun', 'bx-moon');
  } else {
    rootElement.classList.remove('dark-mode'); // Switch to Light Mode
    rootElement.classList.add('light-mode');
    darkModeIcon.classList.replace('bx-moon', 'bx-sun');
  }
};

//for underling WORDS after certain seconds
setTimeout(() => {
  let a = document.getElementById("highlight");
  a.style.transition =
    "opacity 0.5s ease, background-color 0.5s ease, padding 0.5s ease";
  a.style.opacity = "1"; // Fade-in effect
  a.style.backgroundColor = "#FF5722";
  a.style.padding = "0px 5px";
}, 1000);

setTimeout(() => {
  let b = document.getElementById("underline");
  b.style.transition =
    "opacity 0.5s ease, text-decoration-color 0.5s ease, text-underline-offset 0.5s ease";
  b.style.opacity = "1"; // Fade-in effect
  b.style.textDecoration = "underline";
  b.style.textDecorationColor = "#FF5722";
  b.style.textUnderlineOffset = "10px";
}, 2000);

setTimeout(() => {
    let c = document.getElementById("info_text");
    c.style.textDecoration = "underline";
    c.style.textDecorationColor = "#FF5722";
    c.style.textUnderlineOffset = "10px";
  }, 2000);

  setTimeout(() => {
    let d = document.getElementById("r_review");
    d.style.textDecoration = "underline";
    d.style.textDecorationColor = "#FF5722";
    d.style.textUnderlineOffset = "10px";
  }, 2000);

  setTimeout(() => {
    let e = document.getElementById("ab_text");
    e.style.textDecoration = "underline";
    e.style.textDecorationColor = "#FF5722";
    e.style.textUnderlineOffset = "10px";
  }, 2000);


  document.addEventListener("DOMContentLoaded", () => {
    const categoryItems = document.querySelectorAll(".category-item");
    const courseSections = document.querySelectorAll(".courses");
  
    // Add event listeners to all category buttons
    categoryItems.forEach((button) => {
      button.addEventListener("click", () => {
        // Remove active class from all buttons
        categoryItems.forEach((btn) => btn.classList.remove("active"));
  
        // Add active class to the clicked button
        button.classList.add("active");
  
        // Get the target category to show
        const targetCategory = button.getAttribute("data-target");
  
        // Hide all course sections
        courseSections.forEach((section) =>
          section.classList.remove("active")
        );
  
        // Show the target course section
        document.getElementById(targetCategory).classList.add("active");
      });
    });
  
    // Set "AI & Machine Learning" as the default active category
    document.querySelector(".category-item.active").click();
  });
  
//For Search
  function handleSearch(event) {
    event.preventDefault();  // Prevent the form from submitting and reloading the page

    const query = document.getElementById('searchQuery').value;
    const resultDiv = document.getElementById('searchResult');

    if (query) {
      resultDiv.innerHTML = `<h6>Found!</h6>`;
      // Here, you could add custom logic to fetch actual results (e.g., from an API or database)
    } else {
      resultDiv.innerHTML = '<h3>No search query provided.</h3>';
    }
  }