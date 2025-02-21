const MainLayout = () => {
    const isMobile = window.innerWidth < 768;
    const isTablet = window.innerWidth >= 768 && window.innerWidth < 1024;
    const isDesktop = window.innerWidth >= 1024;

    return (
        <Device.Provider value={{ isMobile, isTablet, isDesktop }}>
            <Navbar />
            <main>
                <Outlet /> {/* Здесь рендерятся дочерние маршруты */}
            </main>
            <Footer />
        </Device.Provider>
    );
};

export default MainLayout;