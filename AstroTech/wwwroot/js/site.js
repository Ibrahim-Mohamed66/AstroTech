// Toggle between login and register forms
document.addEventListener('DOMContentLoaded', function () {
    const loginForm = document.getElementById('loginForm');
    const registerForm = document.getElementById('registerForm');
    const switchToRegister = document.getElementById('switchToRegister');
    const switchToLogin = document.getElementById('switchToLogin');

    // Switch to Register form
    switchToRegister.addEventListener('click', function (e) {
        e.preventDefault();
        loginForm.classList.remove('active');
        registerForm.classList.add('active');
    });

    // Switch to Login form
    switchToLogin.addEventListener('click', function (e) {
        e.preventDefault();
        registerForm.classList.remove('active');
        loginForm.classList.add('active');
    });

    // Toggle password visibility
    window.togglePasswordVisibility = function (inputId, toggleElement) {
        const passwordInput = document.getElementById(inputId);
        const icon = toggleElement.querySelector('i');

        if (passwordInput.type === 'password') {
            passwordInput.type = 'text';
            icon.classList.remove('fa-eye');
            icon.classList.add('fa-eye-slash');
        } else {
            passwordInput.type = 'password';
            icon.classList.remove('fa-eye-slash');
            icon.classList.add('fa-eye');
        }
    };

    // Form validation
    const validateEmail = (email) => {
        return String(email)
            .toLowerCase()
            .match(
                /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/
            );
    };

    const validatePassword = (password) => {
        return password.length >= 8;
    };

    // Login form validation
    document.querySelector('#loginForm form').addEventListener('submit', function (e) {
        e.preventDefault();
        let isValid = true;

        const email = document.getElementById('loginEmail');
        const password = document.getElementById('loginPassword');

        // Validate email
        if (!validateEmail(email.value)) {
            email.classList.add('is-invalid');
            if (!email.nextElementSibling || !email.nextElementSibling.classList.contains('invalid-feedback')) {
                const feedback = document.createElement('div');
                feedback.classList.add('invalid-feedback');
                feedback.textContent = 'Please enter a valid email address';
                email.parentNode.appendChild(feedback);
            }
            isValid = false;
        } else {
            email.classList.remove('is-invalid');
            if (email.nextElementSibling && email.nextElementSibling.classList.contains('invalid-feedback')) {
                email.nextElementSibling.remove();
            }
        }

        // Validate password
        if (!validatePassword(password.value)) {
            password.classList.add('is-invalid');
            if (!password.nextElementSibling || !password.nextElementSibling.classList.contains('invalid-feedback')) {
                const feedback = document.createElement('div');
                feedback.classList.add('invalid-feedback');
                feedback.textContent = 'Password must be at least 8 characters';
                password.parentNode.appendChild(feedback);
            }
            isValid = false;
        } else {
            password.classList.remove('is-invalid');
            if (password.nextElementSibling && password.nextElementSibling.classList.contains('invalid-feedback')) {
                password.nextElementSibling.remove();
            }
        }

        if (isValid) {
            // Submit form or handle login logic
            alert('Login successful! (This is a demo)');
        }
    });

    // Register form validation
    document.querySelector('#registerForm form').addEventListener('submit', function (e) {
        e.preventDefault();
        let isValid = true;

        const firstName = document.getElementById('firstName');
        const lastName = document.getElementById('lastName');
        const email = document.getElementById('registerEmail');
        const password = document.getElementById('registerPassword');
        const confirmPassword = document.getElementById('confirmPassword');
        const termsCheck = document.getElementById('termsCheck');

        // Validate first name
        if (firstName.value.trim() === '') {
            firstName.classList.add('is-invalid');
            if (!firstName.nextElementSibling || !firstName.nextElementSibling.classList.contains('invalid-feedback')) {
                const feedback = document.createElement('div');
                feedback.classList.add('invalid-feedback');
                feedback.textContent = 'First name is required';
                firstName.parentNode.appendChild(feedback);
            }
            isValid = false;
        } else {
            firstName.classList.remove('is-invalid');
            if (firstName.nextElementSibling && firstName.nextElementSibling.classList.contains('invalid-feedback')) {
                firstName.nextElementSibling.remove();
            }
        }

        // Validate last name
        if (lastName.value.trim() === '') {
            lastName.classList.add('is-invalid');
            if (!lastName.nextElementSibling || !lastName.nextElementSibling.classList.contains('invalid-feedback')) {
                const feedback = document.createElement('div');
                feedback.classList.add('invalid-feedback');
                feedback.textContent = 'Last name is required';
                lastName.parentNode.appendChild(feedback);
            }
            isValid = false;
        } else {
            lastName.classList.remove('is-invalid');
            if (lastName.nextElementSibling && lastName.nextElementSibling.classList.contains('invalid-feedback')) {
                lastName.nextElementSibling.remove();
            }
        }

        // Validate email
        if (!validateEmail(email.value)) {
            email.classList.add('is-invalid');
            if (!email.nextElementSibling || !email.nextElementSibling.classList.contains('invalid-feedback')) {
                const feedback = document.createElement('div');
                feedback.classList.add('invalid-feedback');
                feedback.textContent = 'Please enter a valid email address';
                email.parentNode.appendChild(feedback);
            }
            isValid = false;
        } else {
            email.classList.remove('is-invalid');
            if (email.nextElementSibling && email.nextElementSibling.classList.contains('invalid-feedback')) {
                email.nextElementSibling.remove();
            }
        }

        // Validate password
        if (!validatePassword(password.value)) {
            password.classList.add('is-invalid');
            if (!password.nextElementSibling || !password.nextElementSibling.classList.contains('invalid-feedback')) {
                const feedback = document.createElement('div');
                feedback.classList.add('invalid-feedback');
                feedback.textContent = 'Password must be at least 8 characters';
                password.parentNode.appendChild(feedback);
            }
            isValid = false;
        } else {
            password.classList.remove('is-invalid');
            if (password.nextElementSibling && password.nextElementSibling.classList.contains('invalid-feedback')) {
                password.nextElementSibling.remove();
            }
        }

        // Validate confirm password
        if (password.value !== confirmPassword.value) {
            confirmPassword.classList.add('is-invalid');
            if (!confirmPassword.nextElementSibling || !confirmPassword.nextElementSibling.classList.contains('invalid-feedback')) {
                const feedback = document.createElement('div');
                feedback.classList.add('invalid-feedback');
                feedback.textContent = 'Passwords do not match';
                confirmPassword.parentNode.appendChild(feedback);
            }
            isValid = false;
        } else {
            confirmPassword.classList.remove('is-invalid');
            if (confirmPassword.nextElementSibling && confirmPassword.nextElementSibling.classList.contains('invalid-feedback')) {
                confirmPassword.nextElementSibling.remove();
            }
        }

        // Validate terms checkbox
        if (!termsCheck.checked) {
            termsCheck.classList.add('is-invalid');
            if (!termsCheck.nextElementSibling.nextElementSibling || !termsCheck.nextElementSibling.nextElementSibling.classList.contains('invalid-feedback')) {
                const feedback = document.createElement('div');
                feedback.classList.add('invalid-feedback');
                feedback.textContent = 'You must agree to the terms';
                termsCheck.parentNode.appendChild(feedback);
            }
            isValid = false;
        } else {
            termsCheck.classList.remove('is-invalid');
            if (termsCheck.nextElementSibling.nextElementSibling && termsCheck.nextElementSibling.nextElementSibling.classList.contains('invalid-feedback')) {
                termsCheck.nextElementSibling.nextElementSibling.remove();
            }
        }

        if (isValid) {
            // Submit form or handle registration logic
            alert('Registration successful! (This is a demo)');
        }
    });

    // Add animation class to form on load
    setTimeout(() => {
        document.querySelector('.auth-container').classList.add('loaded');
    }, 100);
});